using Kotli.English.Domain.Entities.Schemes;

namespace kotli_english.Services.Interfaces;

public interface IFlashcardService
{
    int CurrentFlashcardNumber { get; }
    int CurrentWordIndex { get; }
    int NumberOfTotalFlascard { get; }
    int NumberOfTotalWord { get; }
    void NextFlashcard();
    Words NextWord();
    bool CanGoNextWord();
    bool CanGoNextFlashcard();
    Task LoadAsync();
    Task SaveAsync(Action<int, int> progressDelegator);
    Task ResetAsync();
    void Response(bool isOk);
}
