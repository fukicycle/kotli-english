using kotli_english.Entities.Schemes;

namespace kotli_english.Repositories.Interfaces;
public interface IWordRepository
{
    Task<Words> GetWordByIdAsync(string wordId);
    Task<IEnumerable<Words>> GetWordListAsync();
    Task AddWordAsync(Words words);
}
