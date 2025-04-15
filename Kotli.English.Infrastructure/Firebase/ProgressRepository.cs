using Firebase.Database;
using Firebase.Database.Query;
using Kotli.English.Domain.Entities.Schemes;
using Kotli.English.Domain.Repositories;
using Kotli.English.Domain.ValueObjects;

namespace Kotli.English.Infrastructure.Firebase;

public sealed class ProgressRepository : IProgressRepository
{
    private readonly FirebaseClient _client = FirebaseClientService.GetClient();
    private const string SCHEME = "progress";

    public async Task<IEnumerable<Progress>> GetProgressListByUserIdAsync(UserId userId)
    {
        IReadOnlyCollection<FirebaseObject<Progress>> objects = await _client.Child(SCHEME).Child(userId.ValueStr).OnceAsync<Progress>();
        return objects.Select(o => o.Object);
    }

    public Task<Progress?> GetProgressByUserIdAndWordIdAsync(UserId userId, WordId wordId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProgressAsync<T>(UserId userId, WordId wordId, string key, T value)
    {
        throw new NotImplementedException();
    }
}
