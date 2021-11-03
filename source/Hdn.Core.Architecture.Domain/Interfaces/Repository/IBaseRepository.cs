using Hdn.Onboarding.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : AuditableEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T Item);
        Task<Guid> GetUserIdFromTokenAsync(string Token);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<int> CountAsync();
        Task<bool> ExistAsync(Guid id);
    }
}
