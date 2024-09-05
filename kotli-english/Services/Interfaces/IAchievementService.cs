namespace kotli_english.Services.Interfaces;

public interface IAchievementService
{
    Task InitializeAsync();
    int Progress { get; }
    int NumberOfStudyWord { get; }
    int NumberOfCompleteGoal { get; }
    int TotalNumberOfGoal { get; }
    int TotalNumberOfWord { get; }
}
