using App.Repository;
using App.Repository.ApiClient;
using System;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient httpClient = new();
ICoinMarketAppExecuter apiExecuter = new CoinMarketAppExecuter("http://localhost:44393", httpClient);

await GetCoins();

async Task GetCoins()
{
    CoinRepository repository = new(apiExecuter);
    var coins = await repository.Get();
    foreach (var coin in coins)
    {
        Console.WriteLine($"Coin : {coin.Name}");
    }
}