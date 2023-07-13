using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using d20TG;
using d20TG.Features.ScenarioSetup.Services;
using d20TG.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICombatScenarioService, CombatScenarioService>();
builder.Services.AddScoped<ICombatScenarioRepository, CombatScenarioRepository>();
builder.Services.AddSingleton<IMyNavigationManager, MyNavigationManager>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
