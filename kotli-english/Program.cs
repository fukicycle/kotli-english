using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using kotli_english;
using kotli_english.Services.Interfaces;
using kotli_english.Services;
using kotli_english.Repositories.Interfaces;
using kotli_english.Repositories;
using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("Default", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient("RandomUser", client => client.BaseAddress = new Uri("https://randomuser.me//api"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSpeechSynthesis();

builder.Services.AddScoped<IFirebaseClientService, FirebaseClientService>();
builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
builder.Services.AddScoped<IWordService, WordService>();
builder.Services.AddScoped<IFlashcardService, FlashcardService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClipboardService, ClipboardService>();
builder.Services.AddScoped<RegexService>();

builder.Services.AddScoped<IndexedDBAccessor>();
var host = builder.Build();
using var scope = host.Services.CreateScope();
await using var indexedDB = scope.ServiceProvider.GetService<IndexedDBAccessor>();
if (indexedDB is not null)
{
    await indexedDB.InitializeAsync();
}
await host.RunAsync();
//await builder.Build().RunAsync();
