using MediatR;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.UpdateCreditCardStatuses
{
    public class UpdateCreditCardStatusesCommand : IRequest
    {
        public int Id { get; set; }
        public string CreditCardStatusCode { get; set; } = string.Empty;
        public string CreditCardStatusName { get; set; } = string.Empty;
    }
}
