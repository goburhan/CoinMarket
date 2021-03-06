using CoinMarketApp.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketApp.Controllers.Auth
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomUserManager customUserManager;
        private readonly ICustomTokenManager customTokenManager;

        public AuthController(ICustomUserManager customUserManager,
            ICustomTokenManager customTokenManager)
        {
            this.customUserManager = customUserManager;
            this.customTokenManager = customTokenManager;
        }

        [HttpPost]
        [Route("/authenticate")]
        public Task<string> Authenticate(UserCredentials userCredentials)
        {
            return Task.FromResult(customUserManager.Authenticate(userCredentials.userName, userCredentials.password));

        }
        [HttpGet]
        [Route("/verifytoken")]
        public Task<bool> Verify(string token)
        {
            return Task.FromResult(customTokenManager.VerifyToken(token));
        }
        [HttpGet]
        [Route("/getuserinfo")]
        public Task<string> GetUserInfoByToken(string token)
        {
            return Task.FromResult(customTokenManager.GetUserInfoByToken(token));
        }

        public class UserCredentials
        {
            public string userName { get; set; }
            public string password { get; set; }

        }
        public class Token
        {
            public string token { get; set; }
        }

    }
}
