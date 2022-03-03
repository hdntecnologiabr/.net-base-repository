using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Enums;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Commands.UpdateTodoItemDetail;

public class UpdateTodoItemDetailCommand : IRequest
{
    public Guid Id { get; set; }

    public Guid ListId { get; set; }

    public PriorityLevel Priority { get; set; }

    public string? Note { get; set; }
}
