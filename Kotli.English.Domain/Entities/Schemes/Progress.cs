namespace Kotli.English.Domain.Entities.Schemes;
public sealed class Progress
{
    public Progress(
        Guid wordId,
        DateTime lastReviewed,
        int correctResponses,
        int incorrectResponses,
        int masteryLevel
    )
    {
        WordId = wordId;
        LastReviewed = lastReviewed;
        CorrectResponses = correctResponses;
        IncorrectResponses = incorrectResponses;
        MasteryLevel = masteryLevel;
    }
    public Guid WordId { get; }
    public DateTime LastReviewed { get; }
    public int CorrectResponses { get; }
    public int IncorrectResponses { get; }
    public int MasteryLevel { get; }
}
