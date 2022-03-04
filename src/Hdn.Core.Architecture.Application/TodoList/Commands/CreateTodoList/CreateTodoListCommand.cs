using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Commands.CreateTodoList;

public class CreateTodoListCommand : IRequest<Guid>
{
    public string? Title { get; set; }
}
