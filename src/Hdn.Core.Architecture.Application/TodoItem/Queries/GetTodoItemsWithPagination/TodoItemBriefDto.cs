using Hdn.Core.Architecture.Application.Common.Mappings;
using Hdn.Core.Architecture.Domain.Entities;

namespace Hdn.Core.Architecture.Application.TodoItem.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItemEntity>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
