using Blazored.LocalStorage;
using kotli_english.Entities.Models;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services.Interfaces;

namespace kotli_english.Services;

public sealed class FlashcardService : IFlashcardService
{
    private const string STORAGE_KEY = "995a2dde-8469-466d-992c-a04087537318_Flashcard_Settigns";
    private readonly IWordRepository _wordRepository;
    private readonly ILocalStorageService _localStorageService;
    private readonly ILogger<FlashcardService> _logger;
    private readonly List<Flashcard> _flashcardList = new List<Flashcard>();
    private int _currentIndex = 0;
    private int _currentNumber = 1;
    private Flashcard? _currentFlashcard = null;
    public FlashcardService(
        IWordRepository wordRepository,
        ILocalStorageService localStorageService,
        ILogger<FlashcardService> logger)
    {
        _wordRepository = wordRepository;
        _localStorageService = localStorageService;
        _logger = logger;
    }

    public bool CanGoNextFlashcard()
    {
        if (!_flashcardList.Any())
        {
            return false;
        }
        if (!_flashcardList.Any(a => a.Number == _currentNumber + 1))
        {
            return false;
        }
        return true;
    }

    public bool CanGoNextWord()
    {
        if (_currentFlashcard == null)
        {
            return false;
        }
        if (_currentFlashcard.WordList.Count <= _currentIndex + 1)
        {
            return false;
        }
        return true;
    }

    private async Task GenerateAsync()
    {
        _currentIndex = 0;
        _currentNumber = 1;
        IEnumerable<Words> wordList = await _wordRepository.GetWordListAsync();
        List<Words> randomList = wordList.OrderBy(a => Random.Shared.Next()).ToList();
        int number = 1;
        while (randomList.Count() > 0)
        {
            var dailyWordList = randomList.Take(10).ToList();
            _flashcardList.Add(new Flashcard(number++, dailyWordList));
            foreach (var item in dailyWordList)
            {
                randomList.Remove(item);
                _logger.LogInformation("Added and removed. {0}, remain: {1}", item.Word, randomList.Count);
            }
        }
        FlashcardSettings flashcardSettings = new FlashcardSettings(_currentNumber, _flashcardList);
        await _localStorageService.SetItemAsync(STORAGE_KEY, flashcardSettings);
    }

    public async Task LoadAsync()
    {
        FlashcardSettings? flashcardSettings = await _localStorageService.GetItemAsync<FlashcardSettings>(STORAGE_KEY);
        if (flashcardSettings == null)
        {
            await GenerateAsync();
        }
        else
        {
            _currentNumber = flashcardSettings.CurrentNumber;
            _currentIndex = 0;
            _flashcardList.AddRange(flashcardSettings.FlashcardList);
        }
        if (CanGoNextFlashcard())
        {
            NextFlashcard();
        }
    }

    public void NextFlashcard()
    {
        if (!_flashcardList.Any())
        {
            throw new Exception("Flash card list is empty.");
        }
        _currentFlashcard = _flashcardList.First(a => a.Number == _currentNumber);
        _currentNumber++;
    }

    public Words NextWord()
    {
        if (_currentFlashcard == null)
        {
            throw new Exception("Current flash card is null.");
        }
        Words word = _currentFlashcard.WordList[_currentIndex];
        _currentIndex++;
        return word;
    }

    public async Task SaveAsync()
    {
        if (_currentFlashcard == null)
        {
            throw new Exception("Current flash card is null.");
        }
        _currentNumber++;
        FlashcardSettings flashcardSettings = new FlashcardSettings(_currentNumber, _flashcardList);
        await _localStorageService.SetItemAsync(STORAGE_KEY, flashcardSettings);
        // _currentFlashcard.WordList;
    }
}
