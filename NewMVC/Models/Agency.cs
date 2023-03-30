using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NewMVC.Models
{
    public class Agency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Agency")]
        public string AgencyName { get; set; }
    }
}
