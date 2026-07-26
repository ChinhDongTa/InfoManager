using InfoManager.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("vi-VN");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("vi-VN");

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorServices(builder.Configuration);
builder.Services.AddAuthorizationCore();
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
