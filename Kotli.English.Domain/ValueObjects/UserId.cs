using Kotli.English.Domain.Exceptions;

namespace Kotli.English.Domain.ValueObjects;

public sealed class UserId : ValueObject<UserId>
{
    public UserId(string value)
    {
        if (!Guid.TryParse(value, out Guid tmp))
        {
            throw new UserIdException("ユーザIDが無効です。");
        }
        if (tmp == Guid.Empty)
        {
            throw new UserIdException("ユーザIDが空です。");
        }
        Value = tmp;
        ValueStr = tmp.ToString();
    }
    public Guid Value { get; }
    public string ValueStr { get; set; }
    protected override bool EqualsCore(UserId other)
    {
        return Value == other.Value;
    }
}
