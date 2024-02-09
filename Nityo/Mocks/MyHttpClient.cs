using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nityo.Mocks
{
    public class MyHttpClient : IMyHttpClient
    {
        private readonly HttpClient _httpClient;

        public MyHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
           
            var response = await _httpClient.GetAsync(url);
            
            var content = await response.Content.ReadAsStringAsync();
            return new HttpResponseMessage()
            {
                StatusCode = response.StatusCode,
                Content = new StringContent(content)
            };
        }
    }
}
