using SolCreditCardManagement.Data;
using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Domain
{
    public class Transaction : BaseDomainModel
    {
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int TransactionTypeId { get; set; }
        public virtual TransactionType? TransactionType { get; set; }
        public int CreditCardId { get; set; }
        public virtual CreditCard? CreditCard { get; set; }
    }
}
