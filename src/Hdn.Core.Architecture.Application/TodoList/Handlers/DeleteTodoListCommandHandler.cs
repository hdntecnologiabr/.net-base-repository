using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Application.TodoList.Commands.DeleteTodoList;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Handlers;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
{
    private readonly ITodoListRepository todoListRepository;

    public DeleteTodoListCommandHandler(ITodoListRepository todoListRepository) =>
        this.todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));

    public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        return await todoListRepository.DeleteAsync(l => l.Id.Equals(request.Id), cancellationToken)
            ? Unit.Value
            : throw new NotFoundException(nameof(TodoListEntity), request.Id);
    }
}
