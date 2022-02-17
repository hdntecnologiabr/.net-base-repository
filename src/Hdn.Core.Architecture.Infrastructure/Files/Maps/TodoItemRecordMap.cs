using System.Globalization;
using Hdn.Core.Architecture.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace Hdn.Core.Architecture.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
