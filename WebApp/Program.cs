using App.Repository.ApiClient;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyApp.ApplicationLogic;
using MyApp.Repository;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton<AuthenticationStateProvider, JwtTokenAuthenticationStateProvider>();

            builder.Services.AddSingleton<ITokenRepository, TokenRepository>();
            builder.Services.AddSingleton<ICoinMarketAppExecuter>( sp=> 
            new CoinMarketAppExecuter(
                "https://localhost:5001", 
                 new HttpClient(),
              
                 sp.GetRequiredService<ITokenRepository>()
                 )); //Executer uses HttpClient, dont need create a client all time so this is singleton

            #region dependency injections

            builder.Services.AddTransient<IApplicationUsersUseCases, ApplicationUsersUseCases>();
            builder.Services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddTransient<IAuthenticationUseCases, AuthenticationUseCases>();

            builder.Services.AddTransient<ICoinsScreenUseCases, CoinsScreenUseCases>(); // Letting know the webapp to use These Usecases
            builder.Services.AddTransient<ICoinRepository, CoinRepository>(); // Letting know the webapp to use These repositories
            
            #endregion

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
