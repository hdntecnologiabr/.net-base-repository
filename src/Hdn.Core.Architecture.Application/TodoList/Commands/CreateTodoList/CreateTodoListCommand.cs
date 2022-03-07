using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Commands.CreateTodoList;

public class CreateTodoListCommand : IRequest<Guid>
{
    public string? Title { get; set; }
}
