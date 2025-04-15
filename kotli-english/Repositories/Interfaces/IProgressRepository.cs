using Kotli.English.Domain.Entities.Schemes;

namespace kotli_english.Repositories.Interfaces;
public interface IProgressRepository
{
    Task<Dictionary<Guid, Progress>> GetProgressListByUserIdAsync(Guid userId);
    Task<Progress?> GetProgressByUserIdAndWordIdAsync(Guid userId, Guid wordId);
    Task UpdateProgressAsync(Guid userId, Progress progress);
}
