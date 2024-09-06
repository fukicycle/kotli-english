using kotli_english.Services.Interfaces;
using Microsoft.JSInterop;

namespace kotli_english.Services;

public sealed class ClipboardService : IClipboardService
{
    private readonly IJSRuntime _runtime;
    public ClipboardService(IJSRuntime runtime)
    {
        _runtime = runtime;
    }
    public async Task CopyToClipboardAsync(string text)
    {
        await _runtime.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}
