using BlazorBootstrap; // Add this line for BlazorBootstrap
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ThingyDexer.Model;
using ThingyDexer.View;
using ThingyDexer.ViewModel;
using ThingyDexer.WASM;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorBootstrap(); // Add this line for BlazorBootstrap

builder.Services.AddThingyDexerModels()
                .AddThingyDexerViews()
                .AddThingyDexerViewModels();

await builder.Build().RunAsync();
