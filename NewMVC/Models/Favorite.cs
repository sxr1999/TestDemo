namespace NewMVC.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
    }
}
