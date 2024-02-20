using FluentValidation;

namespace SolCreditCardManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("El {FirstName} no puede exceder los 50 caracteres");
            RuleFor(p => p.SecondName)
                .NotEmpty().WithMessage("{SecondName} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("El {SecondName} no puede exceder los 50 caracteres");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{LastName} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("El {LastName} no puede exceder los 50 caracteres");
            RuleFor(p => p.SecondLastName)
                .NotEmpty().WithMessage("{SecondLastName} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("El {SecondLastName} no puede exceder los 50 caracteres");
        }
    }
}
