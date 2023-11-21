using FootballTicketManagement.Application.Contracts.Email;
using FootballTicketManagement.Application.Contracts.Logging;
using FootballTicketManagement.Application.Models.Email;
using FootballTicketManagement.Infrastructure.EmailService;
using FootballTicketManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballTicketManagement.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLoger<>), typeof(LoggerAdapter<>));

        return services;
    }
}