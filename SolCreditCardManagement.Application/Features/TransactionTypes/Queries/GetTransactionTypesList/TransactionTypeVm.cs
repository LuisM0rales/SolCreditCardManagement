namespace SolCreditCardManagement.Application.Features.TransactionTypes.Queries.GetTransactionTypesList
{
    public class TransactionTypeVm
    {
        public int Id { get; set; }
        public string? TransactionTypeCode { get; set; }
        public string? TransactionTypeDescription { get; set; }
    }
}
