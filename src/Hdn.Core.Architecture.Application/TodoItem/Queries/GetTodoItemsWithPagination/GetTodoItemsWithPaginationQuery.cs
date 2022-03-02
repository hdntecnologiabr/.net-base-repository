using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hdn.Core.Architecture.Application.Common.Mappings;
using Hdn.Core.Architecture.Application.Common.Models;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

//TODO: adicionar paginacao com o IQueryble package
public class GetTodoItemsWithPaginationQuery : IRequest<TodoItemBriefDto>
{
    public int ListId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
