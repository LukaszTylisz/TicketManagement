using Microsoft.OpenApi.Models;
using Serilog;
using TicketManagement.Application;
using TicketManagement.Identity;
using TicketManagement.Infrastructure;
using TicketManagement.Middleware;
using TicketManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to container.

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddPersistenceServices(builder.Configuration)
    .AddIdentityServices(builder.Configuration)
    .AddControllers();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("all", builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
    })
    .AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket Management API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging()
    .UseHttpsRedirection()
    .UseCors("all")
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();