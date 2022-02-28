using Hdn.Core.Architecture.Domain.Common;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Hdn.Core.Architecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Origins.Motor.v2.RouterInterfaceFunction.Repository.Repositories;
public partial class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
{
    protected readonly ApplicationDbContext context;
    protected readonly DbSet<T> dataset;
    public BaseRepository(ApplicationDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        dataset = context.Set<T>();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        if (result == null)
            return false;

        dataset.Remove(result);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistAsync(Guid id) =>
        await dataset.AnyAsync(p => p.Id.Equals(id));

    public async Task<T> InsertAsync(T item)
    {
        await dataset.AddAsync(item);
        await context.SaveChangesAsync();

        return item;
    }

    public async Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> item)
    {
        await dataset.AddRangeAsync(item);
        await context.SaveChangesAsync();
        return item;
    }

    public async Task<T> SelectAsync(Guid id) =>
        await dataset.AsNoTracking()
                     .SingleOrDefaultAsync(p => p.Id.Equals(id));

    public async Task<IEnumerable<T>> SelectAsync() =>
        await dataset.AsNoTracking()
                     .ToListAsync();

    public async Task<T> UpdateAsync(T item)
    {
        var result = await dataset.FindAsync(item.Id);
        if (result == null)
            return null;//TODO: deveria dar erro? dps olhar uma melhor implementação

        context.Update(item);
        await context.SaveChangesAsync();
        return item;
    }

    #region DisposePattern
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
                context.Dispose();
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}


