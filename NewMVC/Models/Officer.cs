using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace NewMVC.Models
{
    public class Officer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Officer Name (Last, First, MI)")]
        public string? OfficerDisplayName { get; set; }
        [Display(Name = "First Name")]
        public string? OfficerFirstName { get; set; }
        [Display(Name = "MI")]
        public string? OfficerMiddleInitial { get; set; }
        [Display(Name = "Last Name")]
        public string? OfficerLastName { get; set; }

        [ForeignKey("Agency")]
        public int AgencyId { get; set; }
        public Agency? Agency { get; set; }
    }
}
