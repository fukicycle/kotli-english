using kotli_english.Entities.Schemes;

namespace kotli_english.Entities.Models;

public sealed class Flashcard
{
    public Flashcard(int number, List<Words> wordList)
    {
        Number = number;
        WordList = wordList;
    }

    public int Number { get; }
    public List<Words> WordList { get; }
}
