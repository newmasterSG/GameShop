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
}
