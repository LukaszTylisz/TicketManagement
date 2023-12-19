using System.Reflection;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicketManagement.Blazor.UI;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Providers;
using TicketManagement.Blazor.UI.Services;
using TicketManagement.Blazor.UI.Services.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7025"));

builder.Services
    .AddBlazoredToast()
    .AddBlazoredLocalStorage()
    .AddAuthorizationCore()
    .AddScoped<ApiAuthenticationStateProvider>()
    .AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>()
    .AddScoped<ITicketTypeService, TicketTypeService>()
    .AddScoped<ITicketAllocationService, TicketAllocationService>()
    .AddScoped<ITicketRequestService, TicketRequestService>()
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddAutoMapper(Assembly.GetExecutingAssembly());
    
await builder.Build().RunAsync();