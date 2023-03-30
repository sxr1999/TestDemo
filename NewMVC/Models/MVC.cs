using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NewMVC.Models
{
    public class MVC
    {
        [Display(Name = "Hot!")]
        public bool HotYN { get; set; }

        [Display(Name = "NTLS Account")]
        public bool NTLS { get; set; }
    }
}
