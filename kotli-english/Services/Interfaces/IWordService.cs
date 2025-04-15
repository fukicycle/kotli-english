using Kotli.English.Domain.Entities.Schemes;

namespace kotli_english.Services.Interfaces;

public interface IWordService
{
    Task<IEnumerable<Words>> GetWordListAsync();
}
