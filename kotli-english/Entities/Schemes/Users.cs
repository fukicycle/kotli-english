namespace kotli_english.Entities.Schemes;
public sealed class Users
{
    public Users(
        string userId,
        string nickname,
        DateTime registerDateTime,
        string profileImageUrl,
        int currentLevel,
        Dictionary<Guid, Progress> progress
    )
    {
        UserId = userId;
        Nickname = nickname;
        RegisterDateTime = registerDateTime;
        ProfileImageUrl = profileImageUrl;
        CurrentLevel = currentLevel;
        Progress = progress;
        if (Progress == null)
        {
            Progress = new Dictionary<Guid, Progress>();
        }
    }
    public string UserId { get; } // firebase user id
    public string Nickname { get; set; }
    public DateTime RegisterDateTime { get; }
    public string ProfileImageUrl { get; }
    public int CurrentLevel { get; }
    public Dictionary<Guid, Progress> Progress { get; }
}
