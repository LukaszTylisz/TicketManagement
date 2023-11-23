using TicketManagement.Domain;
using TicketManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketManagement.Application.Contracts.Identity;

namespace TicketManagement.Persistence.DatabaseContext;

public class TicketManagementDatabaseContext : DbContext
{
    private readonly IUserService _userService;

    public TicketManagementDatabaseContext(DbContextOptions<TicketManagementDatabaseContext> options,
        IUserService userService) : base(options)
    {
        this._userService = userService;
        Console.WriteLine("DbContext initialized.");
    }

    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<TicketAllocation> TicketAllocations { get; set; }
    public DbSet<TicketRequest> TicketRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketManagementDatabaseContext).Assembly);
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
            entry.Entity.ModifiedBy = _userService.UserId;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.CreatedBy = _userService.UserId;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}