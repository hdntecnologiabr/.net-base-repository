using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Commands.DeleteTodoItem;

public class DeleteTodoItemCommand : IRequest
{
    public Guid Id { get; set; }
}
