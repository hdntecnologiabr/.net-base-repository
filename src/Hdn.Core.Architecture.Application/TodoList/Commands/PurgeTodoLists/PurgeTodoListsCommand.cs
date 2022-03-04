using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Commands.PurgeTodoLists;

//[Authorize(Roles = "Administrator")]
//[Authorize(Policy = "CanPurge")]
public class PurgeTodoListsCommand : IRequest
{
}
