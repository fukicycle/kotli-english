using kotli_english.Services.Interfaces;

namespace kotli_english.Services;

public sealed class AchievementService : IAchievementService
{
    private readonly IFlashcardService _flashcardService;
    public AchievementService(IFlashcardService flashcardService)
    {
        _flashcardService = flashcardService;
    }
    public async Task InitializeAsync()
    {
        await _flashcardService.LoadAsync();
        Progress = Convert.ToInt32(_flashcardService.CurrentFlashcardNumber * 100.0 / _flashcardService.NumberOfTotalFlascard);
        NumberOfStudyWord = _flashcardService.CurrentFlashcardNumber * 10;
        NumberOfCompleteGoal = _flashcardService.CurrentFlashcardNumber;
        TotalNumberOfGoal = _flashcardService.NumberOfTotalFlascard;
        TotalNumberOfWord = _flashcardService.NumberOfTotalWord;
    }
    public int Progress { get; private set; }

    public int NumberOfStudyWord { get; private set; }

    public int NumberOfCompleteGoal { get; private set; }

    public int TotalNumberOfGoal { get; private set; }

    public int TotalNumberOfWord { get; private set; }
}
