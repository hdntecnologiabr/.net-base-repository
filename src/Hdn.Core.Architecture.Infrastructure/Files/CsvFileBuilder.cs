using System.Globalization;
using Hdn.Core.Architecture.Application.Common.Interfaces;
using Hdn.Core.Architecture.Application.TodoLists.Queries.ExportTodos;
using Hdn.Core.Architecture.Infrastructure.Files.Maps;
using CsvHelper;

namespace Hdn.Core.Architecture.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
