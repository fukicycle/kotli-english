
namespace kotli_english.Pages;

public partial class Words
{
    private List<Entities.Schemes.Words> _wordList = new List<Entities.Schemes.Words>();
    private bool _isWordListLoad = true;

    protected override async Task OnInitializedAsync()
    {
        var wordList = await WordService.GetWordListAsync();
        _wordList.AddRange(wordList);
        _isWordListLoad = false;
    }
}
