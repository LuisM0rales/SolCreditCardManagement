using System.Text.Json.Serialization;

namespace SolCreditCardManagement.App.Models
{
    public class TransactionViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [JsonPropertyName("transactionTypeId")]
        public int TransactionTypeId { get; set; }
        [JsonPropertyName("creditCardId")]
        public int CreditCardId { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
