
using kotli_english.Entities.Schemes;

namespace kotli_english.Services.Interfaces;

public interface IUserService
{
    Guid UserId { get; }
    Task RegisterNewUserAsync();
    Task<Users> GetUserAsync();
    Task<bool> IsExistsAsync();
}
