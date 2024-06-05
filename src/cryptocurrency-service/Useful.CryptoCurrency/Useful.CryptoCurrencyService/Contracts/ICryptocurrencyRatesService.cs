using Useful.CryptoCurrencyService.Dto;

namespace Useful.CryptoCurrencyService.Contracts;

public interface ICryptoCurrencyRatesService
{
    /// <summary>
    ///     Get all crypto rates from coincap
    /// </summary>
    /// <param name="token"></param>
    /// <returns>list of RateMode?l</returns>
    Task<IList<Data>?> GetAllCryptoCurrencyRatesAsync(CancellationToken token);
}