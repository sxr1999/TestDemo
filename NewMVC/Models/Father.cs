using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Father
    {
        [Required(ErrorMessage = "Required field")]
        public virtual string Name { get; set; }
    }
}
