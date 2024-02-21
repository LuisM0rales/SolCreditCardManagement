using FluentValidation;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.UpdateGlobalConfigurations
{
    public class UpdateGlobalConfigurationsCommandValidator : AbstractValidator<UpdateGlobalConfigurationsCommand>
    {
        public UpdateGlobalConfigurationsCommandValidator() 
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{Code} no puede estar en blanco")
                .NotNull();
            RuleFor(p => p.ConfigurationVal)
                .NotEmpty().WithMessage("{ConfigurationVal} no puede estar en blanco")
                .NotNull();
        }
    }
}