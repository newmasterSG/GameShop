using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData.Requests.Interface
{
    public interface IGetRequest : IRequest
    {
        Task<string> GetHtmlFile(HttpClient client, string url);
    }
}
