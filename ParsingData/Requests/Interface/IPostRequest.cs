using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData.Requests.Interface
{
    public interface IPostRequest : IRequest
    {
        Task<string> MakeRequest(string url, string htmlResponse);
    }
}
