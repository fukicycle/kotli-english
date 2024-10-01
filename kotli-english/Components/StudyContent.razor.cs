
using kotli_english.Entities.Models;
using kotli_english.Entities.Schemes;

namespace kotli_english.Components;

public partial class StudyContent
{
    private StudyContentState _currentState = StudyContentState.QUESTION;
    private Words? _word;
    private bool _isStoreProgress = false;

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
            await Task.Run(FlashcardService.SaveAsync);
            _isStoreProgress = false;
        }
    }
}
