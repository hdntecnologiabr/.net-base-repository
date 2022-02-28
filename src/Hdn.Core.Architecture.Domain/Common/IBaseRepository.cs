using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Domain.Interfaces.Repository;

public interface IBaseRepository<T>: IDisposable where T : AuditableEntity
{
    Task<T> InsertAsync(T item);
    Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> item);
    Task<T> UpdateAsync(T item);
    Task<bool> DeleteAsync(Guid id);
    Task<T> SelectAsync(Guid id);
    Task<IEnumerable<T>> SelectAsync();
    Task<bool> ExistAsync(Guid id);
}
