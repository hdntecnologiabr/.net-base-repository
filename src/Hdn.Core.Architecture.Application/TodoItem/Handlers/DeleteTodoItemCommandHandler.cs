using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Application.TodoItem.Commands.DeleteTodoItem;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Handlers;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ITodoItemRepository todoItemRepository;

    public DeleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository) =>
     this.todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));

    public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        return await todoItemRepository.DeleteAsync(l => l.Id.Equals(request.Id), cancellationToken)
            ? Unit.Value
            : throw new NotFoundException(nameof(TodoListEntity), request.Id);
    }
}
