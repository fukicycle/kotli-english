using System.Text.RegularExpressions;
using Blazored.LocalStorage;
using Firebase.Database.Query;
using kotli_english.Entities.Schemes;
using kotli_english.Repositories.Interfaces;
using kotli_english.Services.Interfaces;

namespace kotli_english.Services;

public sealed class UserService : IUserService
{
    private const string USER_ID_STORAGE_KEY = "3de1e385-7892-4860-9531-87ba563d7497_user_id";
    private readonly IUserRepository _userRepository;
    private readonly ILocalStorageService _localStorageService;
    private readonly HttpClient _httpClient;
    private readonly ILogger<UserService> _logger;
    public UserService(IUserRepository userRepository, ILocalStorageService localStorageService, IHttpClientFactory clientFactory, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _localStorageService = localStorageService;
        _httpClient = clientFactory.CreateClient("RandomUser");
        _logger = logger;
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
        string username = await GetRandomUserName();
        await _userRepository.AddUserAsync(
            new Users(
                id.ToString(),
                username,
                DateTime.Now,
                "",
                1,
                Enumerable.Empty<Progress>().ToList()
            )
        );
        await _localStorageService.SetItemAsync(USER_ID_STORAGE_KEY, id);
    }

    private async Task<string> GetRandomUserName()
    {
        var response = await _httpClient.GetAsync("");
        string content = await response.Content.ReadAsStringAsync();
        string value = Regex.Match(content, "\"username\":\"*\"").Value;
        string[] keyValues = value.Split(":");
        if (keyValues.Count() != 2)
        {
            _logger.LogError("ユーザ名の生成に失敗しました。");
            return "New user";
        }
        return keyValues[1].Replace("\"", "");
    }

    public async Task SetUserIdFromQueryAsync(Guid userId)
    {
        UserId = userId;
        await _localStorageService.SetItemAsync(USER_ID_STORAGE_KEY, UserId);
    }
}
