using CoinMarketApp.Core.Models;
using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationLogic
{
    public class CoinsScreenUseCases : ICoinsScreenUseCases
    //each method will represent different usecase
    {
        private readonly ICoinRepository coinRepository;

        public CoinsScreenUseCases(ICoinRepository coinRepository)
        {
            this.coinRepository = coinRepository;
        }

        public async Task<IEnumerable<Coin>> ViewCoinsAsync()
        {
            return await coinRepository.GetAsync();
        }
        public async Task<Coin> ViewCoinById(int coinId)
        {
            return await coinRepository.GetCoinByIdAsync(coinId);
        }

        public async Task UpdateCoin(Coin coin)
        {
            await coinRepository.UpdateAsync(coin);
        }
        public async Task<int> CreateCoin(Coin coin)
        {
           return  await coinRepository.CreateAsync(coin);
        }
        public async Task DeleteCoin(int coinId)
        {
            await coinRepository.DeleteAsync(coinId);
        }
    }
}
