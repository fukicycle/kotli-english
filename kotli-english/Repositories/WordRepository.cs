using Firebase.Database;
using Firebase.Database.Query;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services;

namespace kotli_english.Repositories;
public sealed class WordRepository : IWordRepository
{
    private const string SCHEME_NAME = "words";
    private readonly FirebaseClient _client;
    public WordRepository(IFirebaseClientService firebaseClientService)
    {
        _client = firebaseClientService.Client;
    }
    public async Task AddWordAsync(Words words)
    {
        if (words.WordId == Guid.Empty)
        {
            throw new ArgumentException("Please provide word id.");
        }
        await _client.Child(SCHEME_NAME)
                     .Child(words.WordId.ToString())
                     .PutAsync(words);
    }

    public async Task<Words> GetWordByIdAsync(string wordId)
    {
        return await _client.Child(SCHEME_NAME).Child(wordId).OnceSingleAsync<Words>();
    }

    public async Task<IEnumerable<Words>> GetWordsAsync()
    {
        IReadOnlyCollection<FirebaseObject<Words>> items =
            await _client.Child(SCHEME_NAME).OnceAsync<Words>();
        return items.Select(a => a.Object);
    }
}
