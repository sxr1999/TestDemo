using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        public int LocationId { get; set; }
        [ValidateNever]
        public Location? Location { get; set; }
    }
}
