using Firebase.Database;
using Firebase.Database.Query;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services;

namespace kotli_english.Repositories;
public sealed class ProgressRepository : IProgressRepository
{
    private const string SCHEME_NAME = "progress";
    private readonly FirebaseClient _client;
    public ProgressRepository(IFirebaseClientService firebaseClientService)
    {
        _client = firebaseClientService.Client;
    }
    public async Task AddProgressAsync(string userId, Progress progress)
    {
        await _client.Child(SCHEME_NAME).Child(userId).Child(progress.WordId.ToString()).PutAsync(progress);
    }

    public async Task<Progress> GetProgressByUserIdAndWordIdAsync(string userId, string wordId)
    {
        return await _client.Child(SCHEME_NAME).Child(userId).Child(wordId).OnceSingleAsync<Progress>();
    }

    public async Task<IEnumerable<Progress>> GetProgressByUserIdAsync(string userId)
    {
        IReadOnlyCollection<FirebaseObject<Progress>> items =
            await _client.Child(SCHEME_NAME).Child(userId).OnceAsync<Progress>();
        return items.Select(a => a.Object);
    }

    public async Task UpdateProgressAsync(string userId, Progress progress)
    {
        await _client.Child(SCHEME_NAME).Child(userId).Child(progress.WordId.ToString()).PutAsync(progress);
    }
}
