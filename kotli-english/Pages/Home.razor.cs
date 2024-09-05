
using kotli_english.Entities.Schemes;

namespace kotli_english.Pages;

public partial class Home
{
    private Users? _user;
    protected override async Task OnInitializedAsync()
    {
        bool isRegistered = await UserService.IsExistsAsync();
        if (isRegistered)
        {
            _user = await UserService.GetUserAsync();
        }
        else
        {
            //welcome page???
            //test add user.
            //TODO
            await UserService.RegisterNewUserAsync();
            NavigationManager.NavigateTo("", true);
        }
    }
}
