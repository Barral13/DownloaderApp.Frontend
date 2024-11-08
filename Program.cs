using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DownloaderApp.Frontend;
using Microsoft.AspNetCore.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Verifique o ambiente para definir a URL base do HttpClient
if (builder.HostEnvironment.IsDevelopment())
{
    // URL para o ambiente de desenvolvimento (localhost)
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7083/") });
}
else
{
    // URL para o ambiente de produção (Railway)
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://downloaderappapi-production.up.railway.app/") });
}

await builder.Build().RunAsync();
