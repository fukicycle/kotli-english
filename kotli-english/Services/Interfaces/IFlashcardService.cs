using kotli_english.Entities.Models;
using kotli_english.Entities.Schemes;

namespace kotli_english.Services.Interfaces;

public interface IFlashcardService
{
    void NextFlashcard();
    Words NextWord();
    bool CanGoNextWord();
    bool CanGoNextFlashcard();
    Task LoadAsync();
    Task SaveAsync();
}
