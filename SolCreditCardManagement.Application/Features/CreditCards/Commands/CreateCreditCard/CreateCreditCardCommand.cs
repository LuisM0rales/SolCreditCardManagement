using MediatR;

namespace SolCreditCardManagement.Application.Features.CreditCards.Commands.CreateCreditCard
{
    public class CreateCreditCardCommand : IRequest<int>
    {
        public string EmbossedName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public double? LimitCard { get; set; }
        public double InterestRate { get; set; } = 0.0;
        public int CreditCardStatusId { get; set; }
        public int CustomerId { get; set; }
    }
}
