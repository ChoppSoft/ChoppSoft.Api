using Newtonsoft.Json;
using System.Net;
using System.Security.Authentication;

namespace ChoppSoft.Infra.Helpers
{
    public class HttpHelper
    {
        protected string Url;
        protected HttpClient httpClient;

        public HttpHelper(string url)
        {
            Url = url;
            httpClient = ClientBase();
        }

        public async Task<T> GetAsync<T>()
        {
            var response = await httpClient.GetAsync(Url);

            response.EnsureSuccessStatusCode();

            return await MakeReturn<T>(response);
        }

        private async Task<T> MakeReturn<T>(HttpResponseMessage response)
        {
            var resp = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(resp);
        }

        private HttpClient ClientBase()
        {
            var httpClientHandler = new HttpClientHandler();

            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;

            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, errors) => true;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            httpClientHandler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;

            httpClientHandler.UseDefaultCredentials = false;

            return new HttpClient(httpClientHandler) { BaseAddress = new Uri(Url) };
        }
    }
}
