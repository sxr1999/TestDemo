using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class WebApplicationUser : IdentityUser
    {
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
