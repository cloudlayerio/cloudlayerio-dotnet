using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.requests
{
    public class RequestBuilder<T> where T : class, IEndpointPath
    {
        private readonly HttpClient _httpClient;
        private const string ApiEndpoint = "https://api.cloudlayer.io/v1/";
        
        public RequestBuilder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<Stream> SendRequest(T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            var content = new StringContent(json);
            
            var url = new Uri(new Uri(ApiEndpoint), obj.Path).ToString();
            var response = await _httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStreamAsync();
        }
    }
}