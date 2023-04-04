using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor;
using MudBlazor.Services;
using SmallApplications_Blazor;
using SmallApplications_Blazor.ViewModels.Beginner;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddTransient<BinaryToDecimalConverterViewModel>();
builder.Services.AddTransient<DollarToCentConverterViewModel>();
builder.Services.AddTransient<RomanToDecimalConverterViewModel>();

await builder.Build().RunAsync();
