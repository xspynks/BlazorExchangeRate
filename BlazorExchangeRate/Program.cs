using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorExchangeRate;
using BlazorExchangeRate.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var exchangeRateApiKey = builder.Configuration["ExchangeRateApiConfig:ApiKey"];

builder.Services.AddSingleton(new ExchangeRateApiConfig() { ApiKey = exchangeRateApiKey });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();