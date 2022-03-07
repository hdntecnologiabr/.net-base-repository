using Hdn.Core.Architecture.Domain.Enums;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Commands.UpdateTodoItemDetail;

public class UpdateTodoItemDetailCommand : IRequest
{
    public Guid Id { get; set; }

    public Guid ListId { get; set; }

    public PriorityLevel Priority { get; set; }

    public string? Note { get; set; }
}
