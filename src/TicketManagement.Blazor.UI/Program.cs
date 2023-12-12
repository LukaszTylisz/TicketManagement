using System.Reflection;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicketManagement.Blazor.UI;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Services;
using TicketManagement.Blazor.UI.Services.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("http://localhost:7233"));

builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();
builder.Services.AddScoped<ITicketAllocationService, TicketAllocationService>();
builder.Services.AddScoped<ITicketRequestService, TicketRequestService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    
await builder.Build().RunAsync();