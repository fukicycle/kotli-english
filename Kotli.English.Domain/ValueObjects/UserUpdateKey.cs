using Kotli.English.Domain.Entities.Schemes;
using Kotli.English.Domain.Exceptions;

namespace Kotli.English.Domain.ValueObjects;

public sealed class UserUpdateKey
{
    public UserUpdateKey(string value)
    {
        if (typeof(Users).GetProperties().Any(p => p.Name == value))
        {
            Value = value;
        }
        else
        {
            throw new UserUpdateKeyException($"指定されたKeyのプロパティは存在しません。:{value}");
        }
    }
    public string Value { get; }
}
