
using Microsoft.JSInterop;

namespace kotli_english
{
    public sealed class IndexedDBAccessor : IAsyncDisposable
    {
        private Lazy<IJSObjectReference> _accessorJsRef = new Lazy<IJSObjectReference>();
        private readonly IJSRuntime _jsRuntime;
        public IndexedDBAccessor(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            await _accessorJsRef.Value.InvokeVoidAsync("initialize");
        }

        private async Task WaitForReferenceAsync()
        {
            if (_accessorJsRef.IsValueCreated is false)
            {
                _accessorJsRef = new Lazy<IJSObjectReference>(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "js/indexedDBStorageAccessor.js"));
            }
        }
        public async ValueTask DisposeAsync()
        {
            if (_accessorJsRef.IsValueCreated)
            {
                await _accessorJsRef.Value.DisposeAsync();
            }
        }

        public async Task<T> GetValueAsync<T>(string collectionName, int id)
        {
            await WaitForReferenceAsync();
            var result = await _accessorJsRef.Value.InvokeAsync<T>("get", collectionName, id);
            return result;
        }

        public async Task SetValueAsync<T>(string collectionName, T value)
        {
            await WaitForReferenceAsync();
            await _accessorJsRef.Value.InvokeVoidAsync("set", collectionName, value);
        }
    }
}
