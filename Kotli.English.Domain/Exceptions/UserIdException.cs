namespace Kotli.English.Domain.Exceptions;

public sealed class UserIdException : Exception
{
    public UserIdException(string message) : base(message) { }
}
