using Newtonsoft.Json;

namespace CheckApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var client = new HttpClient();
            //string jsonbody = string.Empty;
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://api.rawg.io/api/games?key=e5be80adcd7348d9bfe0c55a970b5215&page=5"),
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadAsStringAsync();
            //    jsonbody = body;
            //}

            string folderPath = @"D:\Project\Api-Steam\CheckApi";
            string fileName = "Games.json";
            string subfolder = "JsonFiles";
            string path = Path.Combine(folderPath, subfolder, fileName);
            if (File.Exists(path))
            {
                //using (StreamWriter sw = new StreamWriter(path, true))
                //{
                //    await sw.WriteLineAsync(jsonbody);
                //}

                string jsonContent = await File.ReadAllTextAsync(path);

                var gameList = JsonConvert.DeserializeObject<RootObject>(jsonContent);

                foreach (var game in gameList.Results)
                {
                    Console.WriteLine(game.Name);
                }
            }
        }
    }
}