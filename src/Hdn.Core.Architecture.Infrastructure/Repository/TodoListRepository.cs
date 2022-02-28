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

internal class TodoListRepository : BaseRepository<TodoListEntity>, ITodoListRepository
{
    public TodoListRepository(ApplicationDbContext context) : base(context)
    {

    }
}
