using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ApiValidate.Validation
{
    public class CountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            int Count = (int)value;

            if (Count > 3 && Count < 7)
            {
                return new ValidationResult("Count is not valid, Please try again");
            }
            return ValidationResult.Success;
        }
    }
}
