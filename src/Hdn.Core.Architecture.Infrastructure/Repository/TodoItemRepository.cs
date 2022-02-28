using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Hdn.Core.Architecture.Infrastructure.Persistence;
using Origins.Motor.v2.RouterInterfaceFunction.Repository.Repositories;

namespace Hdn.Core.Architecture.Infrastructure.Repository;

internal class TodoItemRepository : BaseRepository<TodoItemEntity>, ITodoItemRepository
{
    public TodoItemRepository(ApplicationDbContext context): base(context)
    {

    }
}
