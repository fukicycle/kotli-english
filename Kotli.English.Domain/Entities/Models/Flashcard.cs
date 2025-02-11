using Kotli.English.Domain.Entities.Schemes;

namespace Kotli.English.Domain.Entities.Models;

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
