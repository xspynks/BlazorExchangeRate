namespace BlazorExchangeRate.Services;

public interface IExchangeCurrencyService
{
    Task<double> ConvertUsdToBrl(double usdValue);

}