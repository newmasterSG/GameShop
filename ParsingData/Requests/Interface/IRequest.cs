using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData.Requests.Interface
{
    public interface IRequest
    {
        string Url { get; set; }
        string Cookies { get; set; }
        string Referer { get; set; }
    }
}
