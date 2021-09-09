using App.Repository.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ICoinMarketAppExecuter webExecuter;
        private readonly ITokenRepository tokenRepository;

        public AuthenticationRepository(ICoinMarketAppExecuter webExecuter, ITokenRepository tokenRepository)
        {
            this.webExecuter = webExecuter;
            this.tokenRepository = tokenRepository;
        }
        public async Task<string> LoginAsync(string userName, string password)
        {
            var tokens = await webExecuter.InvokePostReturnsString("authenticate", new { userName = userName, password = password });
            await tokenRepository.SetToken(tokens);
            return tokens;
        }

        public Task<string> GetUserInfoAsync(string token)
        {

            return webExecuter.InvokePostReturnsString("getuserinfo", new { token = token });
        }
    }
}
