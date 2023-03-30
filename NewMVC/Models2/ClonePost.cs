using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models2
{
    public class ClonePost
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string PostNumber { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int ItemNumber { get; set; }
        public string ItemData { get; set; }
        public int ItemSelected { get; set; }
    }
}
