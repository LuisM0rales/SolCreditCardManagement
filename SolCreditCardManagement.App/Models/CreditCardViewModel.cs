using System.Text.Json.Serialization;

namespace SolCreditCardManagement.App.Models
{
    public class CreditCardViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("embossedName")]
        public string EmbossedName { get; set; } = string.Empty;
        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; } = string.Empty;
        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; } = string.Empty;
        [JsonPropertyName("limitCard")]
        public double? LimitCard { get; set; }
        [JsonPropertyName("interestRate")]
        public double InterestRate { get; set; } = 0.0;
        [JsonPropertyName("creditCardStatusId")]
        public int CreditCardStatusId { get; set; }
        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }
    }
}
