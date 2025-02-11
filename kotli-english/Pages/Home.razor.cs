
using Kotli.English.Domain.Entities.Schemes;
using Microsoft.AspNetCore.Components;

namespace kotli_english.Pages;

public partial class Home
{
    [Parameter]
    [SupplyParameterFromQuery(Name = "user-id")]
    public Guid UserId { get; set; } = Guid.Empty;

    private int _totalWordCount = 535;//hard coding
    private int _studyWordCount = 0;
    private int _master1Count = 0;
    private int _master2Count = 0;
    private int _master3Count = 0;
    private int _userLevel = 0;

    private bool _isNewUser = false;
    private Users? _user;
    protected override async Task OnInitializedAsync()
    {
        bool isRegistered = await UserService.IsExistsAsync();
        if (isRegistered)
        {
            _user = await UserService.GetUserAsync();
        }
        else if (UserId != Guid.Empty)
        {
            await UserService.SetUserIdFromQueryAsync(UserId);
            _user = await UserService.GetUserAsync();
        }
        else
        {
            _isNewUser = true;
        }
        if (_user != null)
        {
            _studyWordCount = _user.Progress.Count;
            _master1Count = _user.Progress.Count(a => a.Value.MasteryLevel == 1);
            _master2Count = _user.Progress.Count(a => a.Value.MasteryLevel == 2);
            _master3Count = _user.Progress.Count(a => a.Value.MasteryLevel >= 3);
            if (_studyWordCount >= 10)
            {
                _userLevel = 1;
            }
            if (_studyWordCount == _totalWordCount)
            {
                _userLevel = 2;
            }
            if (_master1Count == _totalWordCount)
            {
                _userLevel = 3;
            }
            if (_master2Count == _totalWordCount)
            {
                _userLevel = 4;
            }
            if (_master3Count == _totalWordCount)
            {
                _userLevel = 5;
            }
        }
    }

    private async Task CopyUserIdButtonOnClick()
    {
        await ClipboardService.CopyToClipboardAsync(_user!.UserId);
    }
}
