using App.Repository.ApiClient;
using CoinMarketApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public class CoinRepository
    {
        private readonly ICoinMarketAppExecuter CoinMarketAppExecuter;

        public CoinRepository(ICoinMarketAppExecuter CoinMarketAppExecuter)  // by using interface makes this repos doesnt depent on wepapiexecuter DependencyInjection
        {
            this.CoinMarketAppExecuter = CoinMarketAppExecuter;
        }

        public async Task<IEnumerable<Coin>> Get()
        {
            return await CoinMarketAppExecuter.InvokeGet<IEnumerable<Coin>>("api/coin");
        }
    }
}
