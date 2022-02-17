using Hdn.Core.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hdn.Core.Architecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
