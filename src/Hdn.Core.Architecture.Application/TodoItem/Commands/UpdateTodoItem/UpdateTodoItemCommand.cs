using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Commands.UpdateTodoItem;

public class UpdateTodoItemCommand : IRequest
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
