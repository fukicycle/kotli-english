using Blazored.LocalStorage;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services.Interfaces;

namespace kotli_english.Services;

public sealed class UserService : IUserService
{
    private const string USER_ID_STORAGE_KEY = "3de1e385-7892-4860-9531-87ba563d7497_user_id";
    private readonly IUserRepository _userRepository;
    private readonly ILocalStorageService _localStorageService;
    public UserService(IUserRepository userRepository, ILocalStorageService localStorageService)
    {
        _userRepository = userRepository;
        _localStorageService = localStorageService;
    }

    public Guid UserId { get; private set; } = Guid.Empty;

    public async Task<Users> GetUserAsync()
    {
        if (UserId == Guid.Empty)
        {
            throw new Exception("User id is null. Please register first!");
        }
        return await _userRepository.GetUserByIdAsync(UserId.ToString());
    }

    public async Task<bool> IsExistsAsync()
    {
        UserId = await _localStorageService.GetItemAsync<Guid>(USER_ID_STORAGE_KEY);
        return UserId != Guid.Empty;
    }

    public async Task RegisterNewUserAsync()
    {
        Guid id = Guid.NewGuid();
        await _userRepository.AddUserAsync(
            new Users(
                id.ToString(),
                "New user",
                DateTime.Now,
                "",
                1,
                Enumerable.Empty<Progress>().ToList()
            )
        );
        await _localStorageService.SetItemAsync(USER_ID_STORAGE_KEY, id);
    }
}
