using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Commands.UpdateTodoItem;

public class UpdateTodoItemCommand : IRequest
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
