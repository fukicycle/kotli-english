using Firebase.Database;
using Firebase.Database.Query;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services;

namespace kotli_english.Repositories;

public sealed class UserRepository : IUserRepository
{
    private const string SCHEME_NAME = "users";
    private readonly FirebaseClient _client;
    public UserRepository(IFirebaseClientService firebaseClientService)
    {
        _client = firebaseClientService.Client;
    }
    public async Task AddUserAsync(Users user)
    {
        await _client.Child(SCHEME_NAME).PostAsync(user);
    }

    public async Task DeleteUserByIdAsync(string userId)
    {
        await _client.Child(SCHEME_NAME).Child(userId).DeleteAsync();
    }

    public async Task<Users> GetUserByIdAsync(string userId)
    {
        return await _client.Child(SCHEME_NAME).Child(userId).OnceSingleAsync<Users>();
    }

    public async Task UpdateUserAsync(string userId, Users user)
    {
        await _client.Child(SCHEME_NAME).Child(userId).PutAsync(user);
    }
}
