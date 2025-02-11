using Firebase.Database;
using Firebase.Database.Query;
using Kotli.English.Domain.Entities.Schemes;
using Kotli.English.Domain.Repositories;
using Kotli.English.Domain.ValueObjects;

namespace Kotli.English.Infrastructure.Firebase;

public sealed class WordRepository : IWordRepository
{
    private readonly FirebaseClient _client = FirebaseClientService.GetClient();
    private const string SCHEME = "words";
    public async Task AddWordAsync(Words words)
    {
        await _client.Child(SCHEME).Child(words.WordId.ToString()).PutAsync(words);
    }

    public async Task<Words> GetWordByIdAsync(WordId wordId)
    {
        return await _client.Child(SCHEME).Child(wordId.ValueStr).OnceSingleAsync<Words>();
    }

    public async Task<IEnumerable<Words>> GetWordListAsync()
    {
        IReadOnlyCollection<FirebaseObject<Words>> items = await _client.Child(SCHEME).OnceAsync<Words>();
        return items.Select(a => a.Object);
    }
}
