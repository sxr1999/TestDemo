using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models
{
    public class UserInformation : IdentityUser<Guid>
    {
        public int NumberOfCandidates { get; set; }
        public bool Approved { get; set; }
        public bool TermsAndConditions { get; set; }
        public DateTime Modified { get; set; }
        public int CenterType { get; set; }
        public bool IsActive { get; set; }
        public bool IsSchoolAdmin { get; set; }
    }
}
