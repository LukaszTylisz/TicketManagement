using FootballTicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballTicketManagement.Identity.DbContext;

public class FmDatabaseIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public FmDatabaseIdentityDbContext(DbContextOptions<FmDatabaseIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(FmDatabaseIdentityDbContext).Assembly);
    }
}