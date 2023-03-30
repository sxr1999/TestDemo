using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NewMVC.Models
{
    public enum AnEnumType
    {
        noone = 0,
        [Display(Name = "First one")]
        firstone = 1,
        [Display(Name = "Second one")]
        secondone = 2
    }
}
