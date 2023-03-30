using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        { }
        public ApplicationRole(string name) : base(name)
        { }
        public string? RoleDescription { get; set; }
        public string? RoleName { get; set; }

        public int RoleID { get; set; }
        public int CenterID { get; set; }

    }
}
