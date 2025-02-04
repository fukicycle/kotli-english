using Firebase.Database;
using Firebase.Database.Query;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services.Interfaces;

namespace kotli_english.Repositories;
public sealed class ProgressRepository : IProgressRepository
{
    private const string SCHEME_NAME = nameof(Users.Progress);
    private readonly FirebaseClient _client;
    private readonly IUserRepository _userRepository;
    public ProgressRepository(IFirebaseClientService firebaseClientService, IUserRepository userRepository)
    {
        _client = firebaseClientService.Client;
        _userRepository = userRepository;
    }

    public async Task UpdateProgressAsync(Guid userId, Progress progress)
    {
        await _client.Child("users").Child(userId.ToString()).Child(SCHEME_NAME).Child(progress.WordId.ToString()).PutAsync(progress);
    }

    public async Task<Progress?> GetProgressByUserIdAndWordIdAsync(Guid userId, Guid wordId)
    {
        return await _client.Child("users").Child(userId.ToString()).Child(SCHEME_NAME).Child(wordId.ToString()).OnceSingleAsync<Progress>();
    }

    public async Task<Dictionary<Guid, Progress>> GetProgressListByUserIdAsync(Guid userId)
    {
        Users user = await _userRepository.GetUserByIdAsync(userId.ToString());
        return user.Progress;
    }
}
