using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Queries.GetTodos;

public class GetTodosQuery : IRequest<TodosVm>
{
}
