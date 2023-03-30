using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class TestModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage =
            "Gender can not be epmty")]
        public int? EmployeeGender { get; set; }
    }
}
