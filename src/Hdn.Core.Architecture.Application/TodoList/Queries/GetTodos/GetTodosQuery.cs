using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hdn.Core.Architecture.Domain.Enums;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hdn.Core.Architecture.Application.TodoList.Queries.GetTodos;

public class GetTodosQuery : IRequest<TodosVm>
{
}
