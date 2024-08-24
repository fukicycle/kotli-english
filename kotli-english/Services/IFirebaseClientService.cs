using Firebase.Database;

namespace kotli_english.Services;
public interface IFirebaseClientService
{
    Task<string> LoginAsync();
    FirebaseClient Client { get; }
}
