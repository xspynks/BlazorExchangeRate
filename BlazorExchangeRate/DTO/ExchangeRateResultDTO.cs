using System.Text.Json.Serialization;

namespace BlazorExchangeRate.DTO;

public class ExchangeRateResultDTO
{
    [JsonPropertyName("conversion_rates")]
    public Dictionary<string, double> Rates { get; set; }
}