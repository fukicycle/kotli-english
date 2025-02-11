using System;
using Kotli.English.Domain.Exceptions;

namespace Kotli.English.Domain.ValueObjects;

public sealed class WordId : ValueObject<WordId>
{
    public WordId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new WordIdException("WordIdが空です。");
        }
        Value = value;
        ValueStr = value.ToString();
    }
    public WordId(string value)
    {
        if (!Guid.TryParse(value, out var tmp))
        {
            throw new WordIdException("WordIdが無効です。");
        }
        if (tmp == Guid.Empty)
        {
            throw new WordIdException("WordIdが空です。");
        }
        Value = tmp;
        ValueStr = tmp.ToString();
    }
    public Guid Value { get; }
    public string ValueStr { get; }
    protected override bool EqualsCore(WordId other)
    {
        return Value == other.Value;
    }
}
