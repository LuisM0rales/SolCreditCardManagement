using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Domain
{
    public class Statement : BaseDomainModel
    {
        public string? CardNumMask { get; set; }
        public string? Name { get; set;}
        public decimal? CurrentBalance { get; set;}
        public decimal? AvailableBalance { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? MinInterestRate { get; set; }
        public decimal? MinAmountPay { get; set; }
        public decimal? RedeemableInterest { get; set; }
        public decimal? TotalCurrentMonthPurchase { get; set; }
        public decimal? TotalPreviousMonthPurchase { get; set; }
    }
}
