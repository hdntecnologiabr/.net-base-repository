using Hdn.Core.Architecture.Application.TodoList.Commands.CreateTodoList;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Handlers;
public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly ITodoListRepository todoListRepository;

    public CreateTodoListCommandHandler(ITodoListRepository todoListRepository) =>
        this.todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));

    public async Task<Guid> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoListEntity
        {
            Title = request.Title
        };

        await todoListRepository.InsertAsync(entity, cancellationToken);

        return entity.Id;
    }
}
