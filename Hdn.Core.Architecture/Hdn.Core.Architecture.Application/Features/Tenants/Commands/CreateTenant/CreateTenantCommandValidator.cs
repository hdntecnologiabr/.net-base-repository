using FluentValidation;
using hdn.net.architecture.Application.Interfaces.Repositories;

namespace hdn.net.architecture.Application.Features.Tenants.Commands.CreateTenant
{
    public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
    {
        private readonly ITenantRepositoryAsync tenantRepository;

        public CreateTenantCommandValidator(ITenantRepositoryAsync tenantRepository)
        {
            this.tenantRepository = tenantRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }
    }
}
