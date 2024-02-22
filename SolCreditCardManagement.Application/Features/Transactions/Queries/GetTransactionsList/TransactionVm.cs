namespace SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class TransactionVm
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int TransactionTypeId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
