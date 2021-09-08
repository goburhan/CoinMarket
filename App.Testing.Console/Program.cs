using App.Repository.ApiClient;
using MyApp.Repository;
using System;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient httpClient = new();
ICoinMarketAppExecuter apiExecuter = new CoinMarketAppExecuter("https://localhost:5001", httpClient);

await GetCoins();

async Task GetCoins()
{
    CoinRepository repository = new(apiExecuter);
    var coins = await repository.GetAsync();
    foreach (var coin in coins)
    {
        Console.WriteLine($"Coin : {coin.Name}");
    }
}

await GetById(1);

async Task GetById(int id)
{
    CoinRepository repository = new(apiExecuter);
    var coin = await repository.GetCoinByIdAsync(id);
    Console.WriteLine($"Coin : {coin.Name}");
}

Console.ReadLine();