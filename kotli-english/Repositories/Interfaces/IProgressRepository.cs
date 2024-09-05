using kotli_english.Entities.Schemes;

namespace kotli_english.Repositories.Interfaces;
public interface IProgressRepository
{
    Task<IEnumerable<Progress>> GetProgressListByUserIdAsync(Guid userId);
    Task<Progress?> GetProgressByUserIdAndWordIdAsync(Guid userId, Guid wordId);
    Task AddProgressAsync(Guid userId, Progress progress);
}
