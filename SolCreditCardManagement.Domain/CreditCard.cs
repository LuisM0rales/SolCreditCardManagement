using SolCreditCardManagement.Domain;
using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Data
{
    public class CreditCard : BaseDomainModel
    {
        public string EmbossedName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public double? LimitCard { get; set; }
        public double InterestRate { get; set; } = 0.0;
        public int CreditCardStatusId { get; set; }
        public virtual CreditCardStatus? CreditCardStatus { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
