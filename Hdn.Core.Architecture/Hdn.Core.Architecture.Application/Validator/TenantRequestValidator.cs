using FluentValidation;
using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Application.Interfaces.Providers;

namespace Hdn.Core.Architecture.Application.Validator
{
    public class TenantRequestValidator : AbstractValidator<TenantRequest>
    {
        public TenantRequestValidator(IMessageProvider messageProvider)
        {
            RuleFor(p => p.Name)
               .NotEmpty()
                   .WithMessage(p => messageProvider.RequiredField(nameof(p.Name)));

            RuleFor(p => p.Id)
               .NotEmpty()
                   .WithMessage(p => messageProvider.RequiredField(nameof(p.Id)));
        }
    }
}
