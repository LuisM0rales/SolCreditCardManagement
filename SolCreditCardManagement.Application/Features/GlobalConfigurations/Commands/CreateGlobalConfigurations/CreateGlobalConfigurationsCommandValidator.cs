using FluentValidation;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.CreateGlobalConfigurations
{
    public class CreateGlobalConfigurationsCommandValidator : AbstractValidator<CreateGlobalConfigurationsCommand>
    {
        public CreateGlobalConfigurationsCommandValidator() 
        {
            RuleFor(c => c.Code)
                .NotNull().WithMessage("{Code} no puede ser nulo");

            RuleFor(c => c.ConfigurationVal)
                .NotNull().WithMessage("{ConfigurationVal} no puede ser nulo");
        }
    }
}
