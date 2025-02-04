using System.Collections.Immutable;
using Blazored.LocalStorage;
using kotli_english.Entities.Models;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services.Interfaces;

namespace kotli_english.Services;

public sealed class FlashcardService : IFlashcardService
{
    private readonly IWordRepository _wordRepository;
    private readonly IndexedDBAccessor _indexedDBAccessor;
    private readonly IProgressRepository _progressRepository;
    private readonly ILogger<FlashcardService> _logger;
    private ImmutableList<Flashcard> _flashcardList = ImmutableList<Flashcard>.Empty;
    private readonly List<WordUserResponse> _userResponse = new List<WordUserResponse>();
    private readonly IUserService _userService;
    public int CurrentWordIndex { get; private set; } = 0;
    public int CurrentFlashcardNumber { get; private set; } = 1;
    public int NumberOfTotalFlascard { get; private set; } = 1;
    public int NumberOfTotalWord { get; private set; }
    private Flashcard? _currentFlashcard = null;
    private Words? _currentWord = null;
    public FlashcardService(
        IWordRepository wordRepository,
        IndexedDBAccessor indexedDBAccessor,
        IProgressRepository progressRepository,
        IUserService userService,
        ILogger<FlashcardService> logger)
    {
        _wordRepository = wordRepository;
        _indexedDBAccessor = indexedDBAccessor;
        _progressRepository = progressRepository;
        _userService = userService;
        _logger = logger;
    }

    public bool CanGoNextFlashcard()
    {
        if (!_flashcardList.Any())
        {
            return false;
        }
        if (!_flashcardList.Any(a => a.Number == CurrentFlashcardNumber + 1))
        {
            CurrentFlashcardNumber = 1;
            return true;
        }
        return true;
    }

    public bool CanGoNextWord()
    {
        if (_currentFlashcard == null)
        {
            return false;
        }
        if (_currentFlashcard.WordList.Count < CurrentWordIndex + 1)
        {
            return false;
        }
        return true;
    }

    private async Task GenerateAsync()
    {
        CurrentWordIndex = 0;
        CurrentFlashcardNumber = 1;
        IEnumerable<Words> wordList = await _wordRepository.GetWordListAsync();
        List<Words> randomList = wordList.OrderBy(a => Random.Shared.Next()).ToList();
        int number = 1;
        var tmpFlashcardList = new List<Flashcard>();
        while (randomList.Count() > 0)
        {
            var dailyWordList = randomList.Take(10).ToList();
            tmpFlashcardList.Add(new Flashcard(number++, dailyWordList));
            foreach (var item in dailyWordList)
            {
                randomList.Remove(item);
                _logger.LogInformation("Added and removed. {0}, remain: {1}", item.Word, randomList.Count);
            }
        }
        _flashcardList = tmpFlashcardList.ToImmutableList();
        FlashcardSettings flashcardSettings = new FlashcardSettings(CurrentFlashcardNumber, _flashcardList.ToList());
        await _indexedDBAccessor.SetValueAsync(IndexedDBSettings.COL_SETTING, IndexedDBSettings.KEY_FLASHCARD_SETTING, flashcardSettings);
    }

    public async Task LoadAsync()
    {
        FlashcardSettings? flashcardSettings = await _indexedDBAccessor.GetValueAsync<FlashcardSettings>(IndexedDBSettings.COL_SETTING, IndexedDBSettings.KEY_FLASHCARD_SETTING);
        if (flashcardSettings == null)
        {
            await GenerateAsync();
        }
        else
        {
            CurrentFlashcardNumber = flashcardSettings.CurrentNumber;
            CurrentWordIndex = 0;
            _flashcardList = flashcardSettings.FlashcardList.ToImmutableList();
        }
        if (CanGoNextFlashcard())
        {
            NextFlashcard();
        }
        NumberOfTotalFlascard = _flashcardList.Count;
        NumberOfTotalWord = _flashcardList.Sum(a => a.WordList.Count);
    }

    public void NextFlashcard()
    {
        if (!_flashcardList.Any())
        {
            throw new Exception("Flash card list is empty.");
        }
        _currentFlashcard = _flashcardList.First(a => a.Number == CurrentFlashcardNumber);
        CurrentFlashcardNumber++;
    }

    public Words NextWord()
    {
        if (_currentFlashcard == null)
        {
            throw new Exception("Current flash card is null.");
        }
        _currentWord = _currentFlashcard.WordList[CurrentWordIndex];
        CurrentWordIndex++;
        return _currentWord;
    }

    public async Task SaveAsync(Action<int, int> progressDelegator)
    {
        if (_currentFlashcard == null)
        {
            throw new Exception("Current flash card is null.");
        }
        FlashcardSettings flashcardSettings = new FlashcardSettings(CurrentFlashcardNumber, _flashcardList.ToList());
        await _indexedDBAccessor.SetValueAsync(IndexedDBSettings.COL_SETTING, IndexedDBSettings.KEY_FLASHCARD_SETTING, flashcardSettings);
        int total = _userResponse.Count;
        int current = 1;
        foreach (var response in _userResponse)
        {
            Progress? progress = await _progressRepository.GetProgressByUserIdAndWordIdAsync(_userService.UserId,response.Word.WordId);
            int ok = 0;
            int ng = 0;
            if (progress == default)
            {
                if (response.IsOk)
                {
                    ok = 1;
                }
                else
                {
                    ng = 1;
                }
                progress = new Progress(response.Word.WordId, DateTime.Now, ok, ng, ok);
                await _progressRepository.UpdateProgressAsync(_userService.UserId, progress);
            }
            else
            {
                int tmpOk = progress.CorrectResponses;
                ok = progress.CorrectResponses;
                ng = progress.IncorrectResponses;
                if (response.IsOk)
                {
                    ok++;
                }
                else
                {
                    ng++;
                }
                int master = progress.MasteryLevel;
                if (ok % 2 == 0 && tmpOk != ok)
                {
                    master++;
                }
                progress = new Progress(response.Word.WordId, DateTime.Now, ok, ng, master);
                await _progressRepository.UpdateProgressAsync(_userService.UserId, progress);
            }
            progressDelegator.Invoke(total, current);
            current++;
        }
        _userResponse.Clear();
    }

    public async Task ResetAsync()
    {
        _flashcardList.Clear();
        _userResponse.Clear();
        await GenerateAsync();
    }

    public void Response(bool isOk)
    {
        if (_currentWord == null)
        {
            throw new Exception("Current word is null.");
        }
        _userResponse.Add(new WordUserResponse(isOk, _currentWord));
    }
}
