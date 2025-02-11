using Firebase.Database;

namespace Kotli.English.Infrastructure.Firebase;

public static class FirebaseClientService
{
    private const string URI = @"https://english-master-5ca79-default-rtdb.firebaseio.com/";
    private static readonly FirebaseClient _client = new FirebaseClient(URI);
    public static FirebaseClient GetClient()
    {
        return _client;
    }

}
