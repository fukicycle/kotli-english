
using Firebase.Database;

namespace kotli_english.Services;
public sealed class FirebaseClientService : IFirebaseClientService
{
    private const string URI = @"https://english-master-5ca79-default-rtdb.firebaseio.com/";

    public FirebaseClientService()
    {
        Client = new FirebaseClient(URI, new FirebaseOptions
        {
            AuthTokenAsyncFactory = LoginAsync
        });
    }
    public FirebaseClient Client { get; }

    public Task<string> LoginAsync()
    {
        //TODO(implement with login on prod env.)
        return Task.FromResult("");
    }
}
