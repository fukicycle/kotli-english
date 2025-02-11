using Kotli.English.Domain.Entities.Schemes;
using Kotli.English.Domain.ValueObjects;

namespace Kotli.English.Domain.Repositories;

public interface IWordRepository
{
    Task<Words> GetWordByIdAsync(WordId wordId);
    Task<IEnumerable<Words>> GetWordListAsync();
    Task AddWordAsync(Words words);
}
