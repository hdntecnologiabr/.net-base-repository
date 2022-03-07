using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Application.TodoItem.Commands.UpdateTodoItemDetail;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Handlers;
public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly ITodoItemRepository todoItemRepository;

    public UpdateTodoItemDetailCommandHandler(ITodoItemRepository todoItemRepository) =>
        this.todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));

    public async Task<Unit> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await todoItemRepository.SelectAsync(l => l.Id.Equals(request.Id), cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItemEntity), request.Id);
        }

        entity.ListId = request.ListId;
        entity.Priority = request.Priority;
        entity.Note = request.Note;

        await todoItemRepository.UpdateAsync(entity, cancellationToken);

        return Unit.Value;
    }
}
