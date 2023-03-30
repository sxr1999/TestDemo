using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Parent : IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        public int Count { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Count > 3 && Count < 7)
            {
                yield return new ValidationResult("Count is not valid, Please try again");
            } 
        }
    }
}
