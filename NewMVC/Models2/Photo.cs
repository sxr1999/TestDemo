using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models2
{
    public class Photo
    {
        [Required(ErrorMessage = "Please enter file name")]
        public string FileName { get; set; }
        [Required(ErrorMessage = "Please select file")]
        public IFormFile ImageFile { get; set; }
    }
}
