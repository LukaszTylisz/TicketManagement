using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity.DbContext;

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