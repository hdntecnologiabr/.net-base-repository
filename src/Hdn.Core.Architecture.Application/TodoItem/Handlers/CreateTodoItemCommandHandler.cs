using Hdn.Core.Architecture.Application.TodoItem.Commands.CreateTodoItem;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Handlers;

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
{
    private readonly ITodoItemRepository todoItemRepository;

    public CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository) =>
        this.todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));

    public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entityToCreate = new TodoItemEntity
        {
            ListId = request.ListId,
            Title = request.Title,
        };
        var entityResponse = await todoItemRepository.InsertAsync(entityToCreate);

        return entityResponse.Id;
    }
}
