using Application.DTO;
using PagedList;

namespace UI.Models.Search
{
    public class SearchViewModel
    {
        public string GameName { get; set; }
        public List<GameDTO> SearchResults { get; set; }
        public IPagedList<GameDTO> PagedSearchResults { get; set; }
    }
}
