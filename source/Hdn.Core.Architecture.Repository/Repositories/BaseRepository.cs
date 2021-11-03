using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Hdn.Core.Architecture.Repository.Context;
using Hdn.Onboarding.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Repository.Repositories
{
    public partial class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<T> dataset;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.dataset = context.Set<T>();
        }

        public Task<Guid> GetUserIdFromTokenAsync(string Token)
        {
            throw new NotImplementedException();
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

            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            dataset.Add(item);

            await context.SaveChangesAsync();

            return item;
        }

        public virtual async Task<T> SelectAsync(Guid id) =>
            await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

        public async Task<IEnumerable<T>> SelectAsync() =>
            await dataset.ToListAsync();

        public async Task<int> CountAsync() =>
            await dataset.CountAsync();

        public async Task<T> UpdateAsync(T Item)
        {
            var result = await dataset.FindAsync(Item.Id);
            if (result == null)
                return null;

            context.Update(Item);
            await context.SaveChangesAsync();

            return Item;
        }
    }
}
