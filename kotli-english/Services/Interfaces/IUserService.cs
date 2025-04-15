
using Kotli.English.Domain.Entities.Schemes;

namespace kotli_english.Services.Interfaces;

public interface IUserService
{
    Guid UserId { get; }
    Task<Guid> RegisterNewUserAsync();
    Task<Users> GetUserAsync();
    Task<bool> IsExistsAsync();
    Task SetUserIdFromQueryAsync(Guid userId);
}
