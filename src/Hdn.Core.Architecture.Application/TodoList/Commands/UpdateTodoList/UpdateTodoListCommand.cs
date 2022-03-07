using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Commands.UpdateTodoList;

public class UpdateTodoListCommand : IRequest
{
    public Guid Id { get; set; }

    public string? Title { get; set; }
}
