using System.Text.Json;
using BlazorExchangeRate.Configurations;
using BlazorExchangeRate.DTO;

namespace BlazorExchangeRate.Services;

public class ExchangeCurrencyService
{
    private readonly HttpClient httpCLient;
    private readonly ExchangeRateApiConfig exchangeRateApiConfig;

    public ExchangeCurrencyService(IHttpClientFactory httpClientFactory, ExchangeRateApiConfig exchangeRateApiConfig)
    {
        httpCLient = httpClientFactory.CreateClient("ExchangeCurrencyService");
        this.exchangeRateApiConfig = exchangeRateApiConfig;
    }

    public async Task<double> ConvertUsdToBrl(double usdValue)
    {
        using (var httpResponse = await httpCLient.GetAsync($"/v6/{exchangeRateApiConfig.ApiKey}/latest/USD"))
        {
            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var errorResult = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(errorResult);
            }

            var jsonString = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ExchangeRateResultDTO>(jsonString);
            var brlValueToOneUsd = result.Rates["BRL"];

            var resultInBrl = Math.Round(usdValue * brlValueToOneUsd, 2);

            return resultInBrl;
        }
    }
}