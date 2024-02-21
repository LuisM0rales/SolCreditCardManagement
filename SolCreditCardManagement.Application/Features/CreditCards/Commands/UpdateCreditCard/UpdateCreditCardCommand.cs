using MediatR;

namespace SolCreditCardManagement.Application.Features.CreditCards.Commands.UpdateCreditCard
{
    public class UpdateCreditCardCommand :IRequest
    {
        public int Id { get; set; }
        public double InterestRate { get; set; } = 0.0;
    }
}
