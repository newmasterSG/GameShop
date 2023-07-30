using Infrastructure.Models;
using Infrastructure.Models.Games;

namespace ParsingData
{
    public class RootObject<T> where T : EntityBase
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
