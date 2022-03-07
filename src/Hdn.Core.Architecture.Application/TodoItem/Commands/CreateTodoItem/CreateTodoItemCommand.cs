using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Commands.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<Guid>
{
    public Guid ListId { get; set; }

    public string? Title { get; set; }
}
