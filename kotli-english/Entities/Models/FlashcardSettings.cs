using System.Collections.Immutable;

namespace kotli_english.Entities.Models;

public sealed class FlashcardSettings
{
    public FlashcardSettings(int currentNumber, ImmutableList<Flashcard> flashcardList)
    {
        CurrentNumber = currentNumber;
        FlashcardList = flashcardList;
    }
    public int CurrentNumber { get; }
    public ImmutableList<Flashcard> FlashcardList { get; }
}
