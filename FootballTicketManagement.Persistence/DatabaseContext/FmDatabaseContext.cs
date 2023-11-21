using FootballTicketManagement.Domain;
using FootballTicketManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FootballTicketManagement.Persistence.DatabaseContext;

public class FmDatabaseContext : DbContext
{
    public FmDatabaseContext(DbContextOptions<FmDatabaseContext> options) : base(options)
    {
    }

    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<TicketAllocation> TicketAllocations { get; set; }
    public DbSet<TicketRequest> TicketRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FmDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}