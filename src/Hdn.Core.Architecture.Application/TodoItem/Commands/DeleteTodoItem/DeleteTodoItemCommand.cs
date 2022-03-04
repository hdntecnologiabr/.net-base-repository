using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItem.Commands.DeleteTodoItem;

public class DeleteTodoItemCommand : IRequest
{
    public Guid Id { get; set; }
}
