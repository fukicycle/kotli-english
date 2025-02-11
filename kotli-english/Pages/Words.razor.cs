
namespace kotli_english.Pages;

public partial class Words
{
    private List<Kotli.English.Domain.Entities.Schemes.Words> _wordList = new List<Kotli.English.Domain.Entities.Schemes.Words>();
    private bool _isWordListLoad = true;

    protected override async Task OnInitializedAsync()
    {
        var wordList = await WordService.GetWordListAsync();
        _wordList.AddRange(wordList);
        _isWordListLoad = false;
    }
}
