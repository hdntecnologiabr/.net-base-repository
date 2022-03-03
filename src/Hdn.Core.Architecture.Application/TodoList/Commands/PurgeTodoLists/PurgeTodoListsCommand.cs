using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Commands.PurgeTodoLists;

//[Authorize(Roles = "Administrator")]
//[Authorize(Policy = "CanPurge")]
public class PurgeTodoListsCommand : IRequest
{
}

public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
{
    private readonly ITodoListRepository todoListRepository;

    public PurgeTodoListsCommandHandler(ITodoListRepository todoListRepository)
    {
        this.todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));
    }

    public async Task<Unit> Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        await todoListRepository.DeleteRangeAsync(await todoListRepository.SelectAllAsync(cancellationToken: cancellationToken));
        return Unit.Value;//TODO: criar um DeleteAll e um SelectRange
    }
}
