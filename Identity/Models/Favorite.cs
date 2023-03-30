namespace Identity.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }

        public virtual WebApplicationUser WebApplicationUser { get; set; }
    }
}
