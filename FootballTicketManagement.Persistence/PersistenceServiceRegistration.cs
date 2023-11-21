using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Persistence.DatabaseContext;
using FootballTicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballTicketManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FmDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FootballDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<ITicketAllocationRepository, TicketAllocationRepository>();
        services.AddScoped<ITicketRequestRepository, TicketRequestRepository>();

        return services;
    }
}