using CoinMarketApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public interface ICoinRepository
    {
        Task<int> CreateAsync(Coin coin);
        Task DeleteAsync(int id);
        Task<IEnumerable<Coin>> GetAsync();
        Task<Coin> GetCoinByIdAsync(int id);
        Task UpdateAsync(Coin coin);
    }
}