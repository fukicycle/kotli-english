using System;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services.Interfaces;

namespace kotli_english.Services;

public sealed class WordService : IWordService
{
    private readonly IWordRepository _wordRepository;
    private readonly ILogger<WordService> _logger;
    public WordService(IWordRepository wordRepository, ILogger<WordService> logger)
    {
        _wordRepository = wordRepository;
        _logger = logger;
    }
    public async Task<IEnumerable<Words>> GetWordListAsync()
    {
        try
        {
            IEnumerable<Words> wordList = await _wordRepository.GetWordListAsync();
            return wordList.OrderBy(a => a.PartOfSpeech).ThenBy(a => a.Word).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return Enumerable.Empty<Words>();
    }
}
