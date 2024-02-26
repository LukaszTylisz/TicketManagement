using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity.DbContext;

public class TicketManagementDatabaseIdentityDbContext(
    DbContextOptions<TicketManagementDatabaseIdentityDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(TicketManagementDatabaseIdentityDbContext).Assembly);
    }
}