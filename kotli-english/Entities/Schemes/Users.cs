namespace kotli_english.Entities.Schemes;
public sealed class Users
{
    public Users(
        string userId,
        string nickname,
        DateTime registerDateTime,
        string profileImageUrl,
        int currentLevel,
        List<Progress> progress
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
            Progress = new List<Progress>();
        }
    }
    public string UserId { get; } // firebase user id
    public string Nickname { get; set; }
    public DateTime RegisterDateTime { get; }
    public string ProfileImageUrl { get; }
    public int CurrentLevel { get; }
    public List<Progress> Progress { get; }
}
