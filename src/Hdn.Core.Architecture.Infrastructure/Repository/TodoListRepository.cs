using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Hdn.Core.Architecture.Infrastructure.Common;
using Hdn.Core.Architecture.Infrastructure.Context;

namespace Hdn.Core.Architecture.Infrastructure.Repository;

internal class TodoListRepository : BaseRepository<TodoListEntity>, ITodoListRepository
{
    public TodoListRepository(ApplicationDbContext context) : base(context)
    {

    }
}
