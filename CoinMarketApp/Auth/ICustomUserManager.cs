namespace CoinMarketApp.Auth
{
    public interface ICustomUserManager
    {
        string Authenticate(string userName, string password);
    }
}