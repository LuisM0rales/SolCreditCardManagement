using MediatR;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.CreateCreditCardStatuses
{
    public class CreateCreditCardStatusesCommand : IRequest<int>
    {
        public string CreditCardStatusCode { get; set; } = string.Empty;
        public string CreditCardStatusName { get; set; } = string.Empty;
    }
}
