using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity.DbContext;

public class TicketManagementDatabaseIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public TicketManagementDatabaseIdentityDbContext(DbContextOptions<TicketManagementDatabaseIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(TicketManagementDatabaseIdentityDbContext).Assembly);
    }
}