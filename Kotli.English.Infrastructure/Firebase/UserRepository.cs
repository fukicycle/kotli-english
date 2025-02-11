using System.Reflection.PortableExecutable;
using Firebase.Database;
using Firebase.Database.Query;
using Kotli.English.Domain.Entities.Schemes;
using Kotli.English.Domain.Repositories;
using Kotli.English.Domain.ValueObjects;

namespace Kotli.English.Infrastructure.Firebase;

public sealed class UserRepository : IUserRepository
{
    private readonly FirebaseClient _client = FirebaseClientService.GetClient();
    private const string SCHEME = "users";
    public async Task AddUserAsync(Users user)//TODO InputModel的なやつでValidation噛ませたEntitieにする
    {
        await _client.Child(SCHEME).Child(user.UserId).PutAsync(user);
    }

    public async Task DeleteUserByIdAsync(UserId userId)
    {
        await _client.Child(SCHEME).Child(userId.ValueStr).DeleteAsync();
    }

    public async Task<Users> GetUserByIdAsync(UserId userId)
    {
        return await _client.Child(SCHEME).Child(userId.ValueStr).OnceSingleAsync<Users>();
    }

    public async Task UpdateUserAsync<T>(UserId userId, UserUpdateKey key, T value)
    {
        await _client.Child(SCHEME).Child(userId.ValueStr).Child(key.Value).PutAsync(value);
    }
}
