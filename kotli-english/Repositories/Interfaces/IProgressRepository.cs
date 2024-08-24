using kotli_english.Entities.Schemes;

namespace kotli_english.Repositories.Interfaces;
public interface IProgressRepository
{
    Task<IEnumerable<Progress>> GetProgressListByUserIdAsync(string userId);
    Task<Progress> GetProgressByUserIdAndWordIdAsync(string userId, string wordId);
    Task UpdateProgressAsync(string userId, Progress progress);
    Task AddProgressAsync(string userId, Progress progress);
}
