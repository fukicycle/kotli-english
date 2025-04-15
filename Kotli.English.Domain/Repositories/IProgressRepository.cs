using Kotli.English.Domain.Entities.Schemes;
using Kotli.English.Domain.ValueObjects;

namespace Kotli.English.Domain.Repositories;

public interface IProgressRepository
{
    Task<IEnumerable<Progress>> GetProgressListByUserIdAsync(UserId userId);
    Task<Progress?> GetProgressByUserIdAndWordIdAsync(UserId userId, WordId wordId);
    Task UpdateProgressAsync<T>(UserId userId, WordId wordId, string key, T value);
}
