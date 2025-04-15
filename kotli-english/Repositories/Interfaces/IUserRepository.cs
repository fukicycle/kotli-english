using Kotli.English.Domain.Entities.Schemes;

namespace kotli_english.Repositories.Interfaces;
public interface IUserRepository
{
    Task<Users> GetUserByIdAsync(string userId);
    Task UpdateUserAsync(Users user);
    Task AddUserAsync(Users user);
    Task DeleteUserByIdAsync(string userId);
}
