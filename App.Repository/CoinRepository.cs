using App.Repository.ApiClient;
using CoinMarketApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class CoinRepository : ICoinRepository
    {
        private readonly ICoinMarketAppExecuter CoinMarketAppExecuter;

        public CoinRepository(ICoinMarketAppExecuter CoinMarketAppExecuter)  // by using interface makes this repos doesnt depent on wepapiexecuter DependencyInjection
        {
            this.CoinMarketAppExecuter = CoinMarketAppExecuter;
        }

        public async Task<IEnumerable<Coin>> GetAsync()
        {
            return await CoinMarketAppExecuter.InvokeGet<IEnumerable<Coin>>("api/coin");
        }
        public async Task<Coin> GetCoinByIdAsync(int id)
        {
            return await CoinMarketAppExecuter.InvokeGet<Coin>($"api/coin/{id}");
        }
        public async Task<int> CreateAsync(Coin coin)
        {
            coin = await CoinMarketAppExecuter.InvokePost("api/coin", coin);
            return coin.Id;
        }
        public async Task UpdateAsync(Coin coin)
        {
            await CoinMarketAppExecuter.InvokePut($"api/coin/{coin.Id}", coin);

        }
        public async Task DeleteAsync(int id)
        {
            await CoinMarketAppExecuter.InvokeDelete($"api/coin/{id}");
        }
    }
}
