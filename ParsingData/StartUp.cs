using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ParsingData.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData
{
    public static class StartUp
    {
        public static async Task GetTask()
        {
            HttpClient client = new HttpClient();

            GetRequest request = new GetRequest();

            request.Url = "https://store.steampowered.com/tag/browse";
            string html = await request.GetHtmlFile(client, request.Url);

            //await Console.Out.WriteLineAsync(html);

            IConfiguration config = Configuration.Default;
            //Create a new context for evaluating webpages with the given config
            IBrowsingContext context = BrowsingContext.New(config);

            IDocument document = await GetDocument(html, context);

            await Console.Out.WriteLineAsync(document.DocumentElement.OuterHtml);


        }

        public static async Task<IDocument> GetDocument(string html, IBrowsingContext context)
        {
            IDocument document = await context.OpenAsync(req => req.Content(html));

            return document;
        }
    }
}
