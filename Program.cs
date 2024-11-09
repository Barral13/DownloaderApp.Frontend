using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DownloaderApp.Frontend;
using Microsoft.AspNetCore.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Recupera a variável de ambiente API_URL configurada no launchSettings.json
var apiUrl = builder.Configuration["API_URL"] ?? "https://downloaderappapi-production.up.railway.app";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

await builder.Build().RunAsync();
