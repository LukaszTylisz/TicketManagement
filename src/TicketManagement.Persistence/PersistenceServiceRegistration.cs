﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Persistence.DatabaseContext;
using TicketManagement.Persistence.Repositories;

namespace TicketManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TicketManagementDatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TicketDatabaseConnectionString")));

        services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<ITicketTypeRepository, TicketTypeRepository>()
            .AddScoped<ITicketAllocationRepository, TicketAllocationRepository>()
            .AddScoped<ITicketRequestRepository, TicketRequestRepository>();

        return services;
    }
}