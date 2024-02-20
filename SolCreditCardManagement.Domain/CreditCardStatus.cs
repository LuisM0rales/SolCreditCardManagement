using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Data
{
    public class CreditCardStatus : BaseDomainModel
    {
        public string CreditCardStatusCode { get; set; } = string.Empty;
        public string CreditCardStatusName { get; set; } = string.Empty;
    }
}
