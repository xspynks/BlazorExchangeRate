using System.Text.Json.Serialization;

namespace BlazorExchangeRate.DTO;

public class ExchangeRateResultDTO
{
    [JsonPropertyName("converstion_rates")]
    public Dictionary<string, double> Rates { get; set; }
}