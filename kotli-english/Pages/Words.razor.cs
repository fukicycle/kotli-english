
namespace kotli_english.Pages;

public partial class Words
{
    private List<Entities.Schemes.Words> _wordList = new List<Entities.Schemes.Words>();

    protected override Task OnInitializedAsync()
    {
        _wordList.Add(new Entities.Schemes.Words(Guid.NewGuid(), "word", "単語", "noun", "I like this word.", "私はこの単語が好きです。"));
        return base.OnInitializedAsync();
    }
}
