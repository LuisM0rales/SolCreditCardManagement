using System.Text.Json.Serialization;

namespace SolCreditCardManagement.App.Models
{
    public class GlobalConfigurationViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("code")]
        public string? Code { get; set; }
        [JsonPropertyName("configurationVal")]
        public string? ConfigurationVal { get; set; }
    }
}
