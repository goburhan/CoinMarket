using CoinMarketApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.ApplicationLogic
{
    public interface ICoinsScreenUseCases
    {
        Task UpdateCoin(Coin coin);
        Task<IEnumerable<Coin>> ViewCoinsAsync();
        Task<Coin> ViewCoinById(int coinId);
        Task<int> CreateCoin(Coin coin);
        Task DeleteCoin(int coinId);
    }
}