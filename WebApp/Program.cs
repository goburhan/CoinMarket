using App.Repository.ApiClient;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyApp.ApplicationLogic;
using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddTransient<ICoinsScreenUseCases, CoinsScreenUseCases>(); // Letting know the webapp to use These Usecases
            builder.Services.AddTransient<ICoinRepository, CoinRepository>(); // Letting know the webapp to use These repositories
            builder.Services.AddSingleton<ICoinMarketAppExecuter>( sp=> 
            new CoinMarketAppExecuter("https://localhost:5001", 
            new HttpClient(),
            "blazorwasm",
            "secretkey"
            )); //Executer uses HttpClient, dont need create a client all time so this is singleton

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
