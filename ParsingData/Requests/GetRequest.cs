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
        public string Url { get; set; }
        public string Cookies { get; set; }
        public string Referer { get; set; }

        public async Task<string> GetHtmlFile(HttpClient client, string url)
        {
            var companiesResponse = await client.GetAsync(new Uri(url)).ConfigureAwait(false);

            //Get html file
            var htmlResponse = await companiesResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            return htmlResponse;
        }
    }
}
