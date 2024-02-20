using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Domain
{
    public class TransactionType : BaseDomainModel
    {
        public string? TransactionTypeCode { get; set; }
        public string? TransactionTypeDescription { get; set; }
    }
}
