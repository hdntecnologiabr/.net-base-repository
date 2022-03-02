using FluentValidation;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hdn.Core.Architecture.Application.TodoLists.Commands.CreateTodoList;

public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
{
    private readonly ITodoListRepository todoListRepository;

    public CreateTodoListCommandValidator(ITodoListRepository todoListRepository)
    {
        this.todoListRepository = todoListRepository ??  throw new ArgumentNullException(nameof(todoListRepository));

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken) =>
        !await todoListRepository.ExistAsync(l => l.Title == title, cancellationToken);
}
