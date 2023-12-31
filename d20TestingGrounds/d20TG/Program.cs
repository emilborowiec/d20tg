using Blazored.LocalStorage;
using d20TG;
using d20TG.Features.Scenarios.Services;
using d20TG.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IScenarioRepository, ScenarioRepository>();
builder.Services.AddScoped<IScenarioService, ScenarioService>();
builder.Services.AddSingleton<IMyNavigationManager, MyNavigationManager>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
