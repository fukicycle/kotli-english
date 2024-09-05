using kotli_english.Entities.Schemes;

namespace kotli_english.Entities.Models;

public sealed class WordUserResponse
{
    public WordUserResponse(bool isOk, Words word)
    {
        IsOk = isOk;
        Word = word;
        DateTime = DateTime.Now;
    }
    public bool IsOk { get; }
    public Words Word { get; }
    public DateTime DateTime { get; }
}
