
using kotli_english.Entities.Models;
using kotli_english.Entities.Schemes;

namespace kotli_english.Components;

public partial class StudyContent
{
    private StudyContentState _currentState = StudyContentState.QUESTION;
    private Words? _word;
    private bool _isStoreProgress = false;
    private string _loaderMessage = "";

    protected override async Task OnInitializedAsync()
    {
        await Task.Run(async () => await FlashcardService.LoadAsync());
        if (FlashcardService.CanGoNextWord())
        {
            _word = FlashcardService.NextWord();
        }
    }

    private void WordCardOnClick()
    {
        _currentState = StudyContentState.ANSWER;
    }

    private async Task AnswerWordCardOnClick(bool isOk)
    {
        FlashcardService.Response(isOk);
        if (FlashcardService.CanGoNextWord())
        {
            _currentState = StudyContentState.QUESTION;
            _word = FlashcardService.NextWord();
        }
        else
        {
            _currentState = StudyContentState.COMPLETE;
            _isStoreProgress = true;
            UpdateProgress(0, 0);
            await Task.Run(() => FlashcardService.SaveAsync(UpdateProgress));
            _isStoreProgress = false;
        }
    }

    private void UpdateProgress(int total, int current)
    {
        if (total == 0 || current == 0)
        {
            _loaderMessage = "結果を保存中...";
        }
        else
        {
            _loaderMessage = $"結果を保存中...{current}/{total}";
        }
        StateHasChanged();
    }
}
