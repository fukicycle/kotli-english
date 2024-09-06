namespace kotli_english.Services.Interfaces;

public interface IClipboardService
{
    Task CopyToClipboardAsync(string text);
}
