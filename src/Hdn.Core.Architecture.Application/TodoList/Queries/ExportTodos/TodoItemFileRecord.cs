using Hdn.Core.Architecture.Application.Common.Mappings;
using Hdn.Core.Architecture.Domain.Entities;

namespace Hdn.Core.Architecture.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
