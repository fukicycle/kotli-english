
using kotli_english.Entities.Models;
using kotli_english.Entities.Schemes;

namespace kotli_english.Components;

public partial class StudyContent
{
    private StudyContentState _currentState = StudyContentState.QUESTION;
    private Words? _word;

    protected override async Task OnInitializedAsync()
    {
        await FlashcardService.LoadAsync();
        if (FlashcardService.CanGoNextWord())
        {
            _word = FlashcardService.NextWord();
        }
    }

    private void WordCardOnClick()
    {
        _currentState = StudyContentState.ANSWER;
    }

    private async Task AnswerWordCardOnClick()
    {
        if (FlashcardService.CanGoNextWord())
        {
            _currentState = StudyContentState.QUESTION;
            _word = FlashcardService.NextWord();
        }
        else
        {
            await FlashcardService.SaveAsync();
            _currentState = StudyContentState.COMPLETE;
        }
    }
}
