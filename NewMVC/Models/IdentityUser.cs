namespace NewMVC.Models
{
    public class IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
