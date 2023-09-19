using Application.DTO;

namespace UI.Models.Game
{
    public class GameModelView
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Tags {  get; set; }

        public List<string> ScrenShoots { get; set; }

        public List<string> Stores { get; set; }
    }

    public class GamesViewModel
    {
        public List<GameDTO> Games { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }

    public class TagsViewModel
    {
        public List<TagDTO> Tags { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
