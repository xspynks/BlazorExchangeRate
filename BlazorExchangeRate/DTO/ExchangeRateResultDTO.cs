using System.Text.Json.Serialization;

namespace BlazorExchangeRate.DTO;

public class ExchangeRateResultDTO
{
    public ExchangeRateResultDTO()
    {
        Rates = new Dictionary<string, double>();
    }
    [JsonPropertyName("conversion_rates")]
    public Dictionary<string, double> Rates { get; set; }
}