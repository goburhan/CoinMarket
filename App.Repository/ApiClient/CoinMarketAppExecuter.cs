using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.ApiClient
{
    public class CoinMarketAppExecuter : ICoinMarketAppExecuter
    {
        private readonly string baseUrl;
        private readonly HttpClient httpClient;
        private readonly ITokenRepository tokenRepository;

        public CoinMarketAppExecuter(string baseUrl,
            HttpClient httpClient,
            ITokenRepository tokenRepository)
        {
            this.baseUrl = baseUrl;
            this.httpClient = httpClient;
            this.tokenRepository = tokenRepository;
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
     
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            await AddTokenHeader();
            return await httpClient.GetFromJsonAsync<T>(GetUrl(uri));
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
           await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<string> InvokePostReturnsString<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task InvokePut<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PutAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);
        }

        public async Task InvokeDelete(string uri)
        {
            await AddTokenHeader();
            var response = await httpClient.DeleteAsync(GetUrl(uri));
            await HandleError(response);
        }

        private string GetUrl(string uri)
        {
            return $"{baseUrl}/{uri}";
        }

        private async Task HandleError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error);
            }
        }

        private async Task AddTokenHeader()
        {
            if (tokenRepository != null && !string.IsNullOrEmpty(await tokenRepository.GetToken()))
            {
                httpClient.DefaultRequestHeaders.Remove("TokenHeader");
                httpClient.DefaultRequestHeaders.Add("TokenHeader",await tokenRepository.GetToken());
            }
        }

    }

}

