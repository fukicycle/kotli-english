using Kotli.English.Domain.Entities.Schemes;

namespace Kotli.English.Domain.Entities.Models;public sealed class WordUserResponse
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
