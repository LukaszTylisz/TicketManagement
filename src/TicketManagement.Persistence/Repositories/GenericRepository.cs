using TicketManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Persistence.DatabaseContext;

namespace TicketManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly TicketManagementDatabaseContext _context;

    public GenericRepository(TicketManagementDatabaseContext context)
    {
        this._context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int Id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == Id);
    }
}