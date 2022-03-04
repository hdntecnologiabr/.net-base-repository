using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Hdn.Core.Architecture.Infrastructure.Common;
using Hdn.Core.Architecture.Infrastructure.Context;

namespace Hdn.Core.Architecture.Infrastructure.Repository;

internal class TodoItemRepository : BaseRepository<TodoItemEntity>, ITodoItemRepository
{
    public TodoItemRepository(ApplicationDbContext context) : base(context)
    {

    }
}
