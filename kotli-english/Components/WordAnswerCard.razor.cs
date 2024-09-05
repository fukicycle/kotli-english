using kotli_english.Entities.Schemes;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.SpeechSynthesis;

namespace kotli_english.Components;

public partial class WordAnswerCard
{
    [Parameter]
    public Words Word { get; set; } = new Words(Guid.NewGuid(), "Word", "単語", "Noun", "I like this word.", "私はこの単語が好きです。");
    [Parameter]
    public EventCallback ResultOnClick { get; set; }

    private async Task OkButtonOnClick()
    {
        await ResultOnClick.InvokeAsync();
    }

    private async Task NGButtonOnClick()
    {
        await ResultOnClick.InvokeAsync();
    }

    private async Task PlayENButtonOnClick()
    {
        var utterancet = new SpeechSynthesisUtterance
        {
            Text = Word.ExampleSentence,
            Lang = "en-US", // BCP 47 language tag
            Pitch = 0.3, // 0.0 ~ 2.0 (Default 1.0)
            Rate = 1.1, // 0.1 ~ 10.0 (Default 1.0)
            Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
        };
        await SpeechSynthesis.SpeakAsync(utterancet);
    }

    private async Task PlayJPButtonOnClick()
    {
        var utterancet = new SpeechSynthesisUtterance
        {
            Text = Word.ExampleTranslation,
            Lang = "ja-JP", // BCP 47 language tag
            Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
            Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
            Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
        };
        await SpeechSynthesis.SpeakAsync(utterancet);
    }
}
