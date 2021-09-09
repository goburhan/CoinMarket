namespace CoinMarketApp.Auth
{
    public interface IJwtTokenManager
    {
        string CreateToken(string userName);
        string GetUserInfoByToken(string token);
        bool VerifyToken(string token);
    }
}