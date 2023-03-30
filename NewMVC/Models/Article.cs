namespace NewMVC.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Stock stock { get; set; }
        public int StockId { get; set; }
    }
}
