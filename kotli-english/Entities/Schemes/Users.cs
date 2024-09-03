namespace kotli_english.Entities.Schemes;
public sealed class Users
{
    public Users(
        string userId,
        DateTime registerDateTime,
        string profileImageUrl,
        int currentLevel,
        IEnumerable<Guid> learnedWords
    )
    {
        UserId = userId;
        RegisterDateTime = registerDateTime;
        ProfileImageUrl = profileImageUrl;
        CurrentLevel = currentLevel;
        LearnedWords = learnedWords;
    }
    public string UserId { get; } // firebase user id
    public DateTime RegisterDateTime { get; }
    public string ProfileImageUrl { get; }
    public int CurrentLevel { get; }
    public IEnumerable<Guid> LearnedWords { get; }
}
