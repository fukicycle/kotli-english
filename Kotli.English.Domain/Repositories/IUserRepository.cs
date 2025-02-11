using Kotli.English.Domain.Entities.Schemes;
using Kotli.English.Domain.ValueObjects;

namespace Kotli.English.Domain.Repositories;

public interface IUserRepository
{
    Task<Users> GetUserByIdAsync(UserId userId);
    Task UpdateUserAsync<T>(UserId userId, UserUpdateKey key, T value);
    Task AddUserAsync(Users user);
    Task DeleteUserByIdAsync(UserId userId);
}
