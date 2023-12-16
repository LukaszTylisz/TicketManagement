using System.Reflection;
using Blazored.LocalStorage;
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

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("http://localhost:7233"));

builder.Services
    .AddBlazoredLocalStorage()
    .AddAuthorizationCore()
    .AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>()
    .AddScoped<ITicketTypeService, TicketTypeService>()
    .AddScoped<ITicketAllocationService, TicketAllocationService>()
    .AddScoped<ITicketRequestService, TicketRequestService>()
    .AddAutoMapper(Assembly.GetExecutingAssembly());
    
await builder.Build().RunAsync();