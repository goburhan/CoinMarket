using System.Threading.Tasks;

namespace App.Repository.ApiClient
{
    public interface ICoinMarketAppExecuter
    {
        Task InvokeDelete(string uri);
        Task<T> InvokeGet<T>(string uri);
        Task<T> InvokePost<T>(string uri, T obj);
        Task<string> InvokePostReturnsString<T>(string uri, T obj);
        Task InvokePut<T>(string uri, T obj);
    }
}