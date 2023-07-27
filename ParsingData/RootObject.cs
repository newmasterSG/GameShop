using Infrastructure.Models.Games;

namespace ParsingData
{
    public class RootObject
    {
        public int Count { get; set; }
        public List<GamesModel> Results { get; set; }
    }
}
