using Hdn.Core.Architecture.Application.Common.Interfaces;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoLists.Commands.CreateTodoList;

public class CreateTodoListCommand : IRequest<Guid>
{
    public string? Title { get; set; }
}

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

        await todoListRepository.InsertAsync(entity);

        return entity.Id;
    }
}
