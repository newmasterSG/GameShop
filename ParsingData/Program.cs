using AngleSharp;
using ParsingData.Requests;

namespace ParsingData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
           await StartUp.GetTask();
        }
    }
}