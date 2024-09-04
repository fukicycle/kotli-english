using Firebase.Database;

namespace kotli_english.Services.Interfaces;
public interface IFirebaseClientService
{
    Task<string> LoginAsync();
    FirebaseClient Client { get; }
}
