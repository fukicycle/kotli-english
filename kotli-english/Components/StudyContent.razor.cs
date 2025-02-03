
using kotli_english.Entities.Models;
using kotli_english.Entities.Schemes;

namespace kotli_english.Components;

public partial class StudyContent
{
    private StudyContentState _currentState = StudyContentState.QUESTION;
    private Words? _word;
    private bool _isStoreProgress = false;
    private string _loaderMessage = "";

    private async Task InitializeAsync()
    {
        await FlashcardService.LoadAsync();
        if (FlashcardService.CanGoNextWord())
        {
            _word = FlashcardService.NextWord();
        }
        _currentState = StudyContentState.QUESTION;
    }

    protected override async Task OnInitializedAsync()
    {
        await InitializeAsync();
    }

    private async Task NextButtonOnClick()
    {
        if (_currentState == StudyContentState.COMPLETE)
        {
            await InitializeAsync();
        }
        else
        {
            _currentState = StudyContentState.ANSWER;
        }
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
            StateHasChanged();
            UpdateProgress(0, 0);
            await FlashcardService.SaveAsync(UpdateProgress);
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
