using ParsingData.Requests.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData.Requests
{
    public class GetRequest : IGetRequest
    {
        private readonly HttpClient _httpClient;

        private readonly string _url;

        public GetRequest(HttpClient httpClient, string url)
        {
            _httpClient = httpClient;
            _url = url;
        }

        public async Task<string> GetJson(int pageNumber)
        {
            string jsonbody = string.Empty;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_url + pageNumber),
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                jsonbody = body;
            }

            return jsonbody;
        }
    }
}
