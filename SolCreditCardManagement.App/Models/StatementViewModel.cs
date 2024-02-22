using System.Text.Json.Serialization;

namespace SolCreditCardManagement.App.Models
{
    public class StatementViewModel
    {
        [JsonPropertyName("cardNumMask")] 
        public string? CardNumMask { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("currentBalance")]
        public decimal? CurrentBalance { get; set; }
        [JsonPropertyName("availableBalance")]
        public decimal? AvailableBalance { get; set; }
        [JsonPropertyName("creditLimit")]
        public decimal? CreditLimit { get; set; }
        [JsonPropertyName("interestRate")]
        public decimal? InterestRate { get; set; }
        [JsonPropertyName("minInterestRate")]
        public decimal? MinInterestRate { get; set; }
        [JsonPropertyName("minAmountPay")]
        public decimal? MinAmountPay { get; set; }
        [JsonPropertyName("redeemableInterest")]
        public decimal? RedeemableInterest { get; set; }
        [JsonPropertyName("totalCurrentMonthPurchase")]
        public decimal? TotalCurrentMonthPurchase { get; set; }
        [JsonPropertyName("totalPreviousMonthPurchase")]
        public decimal? TotalPreviousMonthPurchase { get; set; }
    }
}
