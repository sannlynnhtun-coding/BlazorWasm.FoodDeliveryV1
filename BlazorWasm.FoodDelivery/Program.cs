using Blazored.LocalStorage;
using BlazorWasm.FoodDelivery;
using BlazorWasm.FoodDelivery.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<IDbService, LocalStorageService>();
builder.Services.AddSingleton<FoodService>();
builder.Services.AddSingleton<NotificationStateContainer>();
builder.Services.AddSingleton<VoucherStateContainer>();
builder.Services.AddSingleton<MenuStateContainer>();

builder.Services.AddMudServices();
await builder.Build().RunAsync();
