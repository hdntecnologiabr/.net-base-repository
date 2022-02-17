using Hdn.Core.Architecture.Application.TodoLists.Queries.ExportTodos;

namespace Hdn.Core.Architecture.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
