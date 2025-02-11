namespace Kotli.English.Domain.Entities.Models;

public sealed class FlashcardSettings
{
    public FlashcardSettings(int currentNumber, List<Flashcard> flashcardList)
    {
        CurrentNumber = currentNumber;
        FlashcardList = flashcardList;
    }
    public int CurrentNumber { get; }
    public List<Flashcard> FlashcardList { get; }
}
