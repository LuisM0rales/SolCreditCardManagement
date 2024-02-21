namespace SolCreditCardManagement.Application.Features.CreditCards.Queries.GetCreditCardsList
{
    public class CreditCardVm
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
