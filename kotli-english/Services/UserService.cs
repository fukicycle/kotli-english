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
    private readonly RegexService _regexService;
    public UserService(IUserRepository userRepository, ILocalStorageService localStorageService, IHttpClientFactory clientFactory, ILogger<UserService> logger, RegexService regexService)
    {
        _userRepository = userRepository;
        _localStorageService = localStorageService;
        _httpClient = clientFactory.CreateClient("Default");
        _logger = logger;
        _regexService = regexService;
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

    public async Task<Guid> RegisterNewUserAsync()
    {
        Guid id = Guid.NewGuid();
        string nickname = await GetRandomUserName();
        await _userRepository.AddUserAsync(
            new Users(
                id.ToString(),
                nickname,
                DateTime.Now,
                "",
                1,
                Enumerable.Empty<Progress>().ToList()
            )
        );
        await _localStorageService.SetItemAsync(USER_ID_STORAGE_KEY, id);
        return id;
    }

    private async Task<string> GetRandomUserName()
    {
        // var response = await _httpClient.GetAsync("");
        // string content = await response.Content.ReadAsStringAsync();
        // string value = _regexService.GetStringBetweenKeywords(content, "\"username\":\"", "\"");
        // _logger.LogInformation(value);
        // if (string.IsNullOrEmpty(value))
        // {
        //     _logger.LogError("ユーザ名の生成に失敗しました。");
        //     return "New user";
        // }
        // return value;
        string[] firstCsvData = await GetCsvDataAsync("first.csv");
        string[] lastCsvData = await GetCsvDataAsync("last.csv");
        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        string first = firstCsvData[Random.Shared.Next(0, firstCsvData.Length - 1)];
        string last = lastCsvData[Random.Shared.Next(0, lastCsvData.Length - 1)];
        string[] intValue = ints.OrderBy(a => Guid.NewGuid()).Take(3).Select(a => a.ToString()).ToArray();
        string upperFirst = $"{Convert.ToString(first.ToUpper().First())}{string.Join("", first.TakeLast(first.Length - 1))}";
        string upperLast = $"{Convert.ToString(last.ToUpper().First())}{string.Join("", last.TakeLast(last.Length - 1))}";
        string nickname = $"{upperFirst}{upperLast}{string.Join("", intValue)}";
        return nickname;
    }

    private async Task<string[]> GetCsvDataAsync(string csvFileName)
    {
        var response = await _httpClient.GetAsync($"csv/{csvFileName}");
        Stream content = await response.Content.ReadAsStreamAsync();
        StreamReader sr = new StreamReader(content);
        string csv = await sr.ReadToEndAsync();
        return csv.Split(",");
    }
    public async Task SetUserIdFromQueryAsync(Guid userId)
    {
        UserId = userId;
        await _localStorageService.SetItemAsync(USER_ID_STORAGE_KEY, UserId);
    }
}
