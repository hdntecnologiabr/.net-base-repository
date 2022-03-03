using Hdn.Core.Architecture.Application.Common.Exceptions;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Commands.UpdateTodoList;

public class UpdateTodoListCommand : IRequest
{
    public Guid Id { get; set; }

    public string? Title { get; set; }
}
