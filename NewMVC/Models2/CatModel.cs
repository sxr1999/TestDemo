using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models2
{
    public class CatModel
    {
        [Required]
        public string IDNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
