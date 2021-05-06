using FluentValidation;
using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Interfaces.Providers;

namespace Hdn.Core.Architecture.Application.Validator
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator(IMessageProvider messageProvider)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage(p => messageProvider.RequiredField(nameof(p.Name)));
        }
    }
}
