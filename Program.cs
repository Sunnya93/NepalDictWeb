using NepalDictWeb.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NepalDictWeb;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var key = builder.Configuration.GetValue<string>("AppSettings:APIKey");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(key);

builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<ExcelService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

await builder.Build().RunAsync();
