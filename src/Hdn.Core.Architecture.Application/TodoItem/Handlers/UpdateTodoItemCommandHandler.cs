using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Application.TodoItem.Commands.UpdateTodoItem;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Handlers;
public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ITodoItemRepository todoItemRepository;

    public UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository) =>
    this.todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));

    public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await todoItemRepository.SelectAsync(l => l.Id.Equals(request.Id), cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(TodoListEntity), request.Id);

        entity.Title = request.Title;

        await todoItemRepository.UpdateAsync(entity, cancellationToken);

        return Unit.Value;
    }
}
