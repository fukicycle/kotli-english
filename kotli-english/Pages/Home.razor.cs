
using kotli_english.Entities.Schemes;
using Microsoft.AspNetCore.Components;

namespace kotli_english.Pages;

public partial class Home
{
    [Parameter]
    [SupplyParameterFromQuery(Name = "user-id")]
    public Guid UserId { get; set; } = Guid.Empty;

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
    }

    private async Task CopyUserIdButtonOnClick()
    {
        await ClipboardService.CopyToClipboardAsync(_user!.UserId);
    }
}
