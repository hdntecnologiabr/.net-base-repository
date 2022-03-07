using Hdn.Core.Architecture.Application.Common.Mappings;
using Hdn.Core.Architecture.Domain.Entities;

namespace Hdn.Core.Architecture.Application.TodoList.Queries.GetTodos;

public class TodoListDto : IMapFrom<TodoListEntity>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Colour { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
