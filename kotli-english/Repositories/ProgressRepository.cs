using Firebase.Database;
using Firebase.Database.Query;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services.Interfaces;

namespace kotli_english.Repositories;
public sealed class ProgressRepository : IProgressRepository
{
    private const string SCHEME_NAME = "users";
    private readonly FirebaseClient _client;
    private readonly IUserRepository _userRepository;
    public ProgressRepository(IFirebaseClientService firebaseClientService, IUserRepository userRepository)
    {
        _client = firebaseClientService.Client;
        _userRepository = userRepository;
    }
    public async Task AddProgressAsync(Guid userId, Progress progress)
    {
        Users user = await _userRepository.GetUserByIdAsync(userId.ToString());
        user.Progress.Add(progress);
        await _client.Child(SCHEME_NAME).Child(userId.ToString()).PutAsync(user);
    }

    public async Task<Progress?> GetProgressByUserIdAndWordIdAsync(Guid userId, Guid wordId)
    {
        // return await _client.Child(SCHEME_NAME).Child(userId).Child(wordId).OnceSingleAsync<Progress>();
        Users user = await _userRepository.GetUserByIdAsync(userId.ToString());
        return user.Progress.FirstOrDefault(a => a.WordId == wordId);
    }

    public async Task<IEnumerable<Progress>> GetProgressListByUserIdAsync(Guid userId)
    {
        Users user = await _userRepository.GetUserByIdAsync(userId.ToString());
        return user.Progress;
    }
}
