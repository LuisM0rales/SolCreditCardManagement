using NuGet.Protocol;
using System.Text;

namespace SolCreditCardManagement.App.APIClients
{
    public class CreditCardManagementAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public CreditCardManagementAPI(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["UrlSettings:UrlApiBase"];
        }

        public async Task<string> GetClientHelper(string url)
        {
            string fullurl = string.Concat(_apiUrl, url);
            var response =  await _httpClient.GetAsync(fullurl);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetClientHelper(string url, int parameter)
        {
            string fullurl = string.Concat(_apiUrl, url,"/",parameter);
            var response = await _httpClient.GetAsync(fullurl);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetClientHelper(string url, string parameter)
        {
            string fullurl = string.Concat(_apiUrl, url, "/", parameter);
            var response = await _httpClient.GetAsync(fullurl);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<HttpResponseMessage> PostClientHelper(string url, object parameter)
        {
            string fullurl = string.Concat(_apiUrl, url);
            var content = new StringContent(parameter.ToJson(), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(fullurl, content);
            var contentRes = await response.Content.ReadAsStringAsync();
            return response;
        }

        public async Task<HttpResponseMessage> PutClientHelper(string url, object parameter)
        {
            string fullurl = string.Concat(_apiUrl, url);
            var content = new StringContent(parameter.ToJson(), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(fullurl, content);
            var contentRes = await response.Content.ReadAsStringAsync();
            return response;
        }
    }
}
