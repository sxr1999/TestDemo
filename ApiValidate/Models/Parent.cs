using ApiValidate.Validation;
using System.ComponentModel.DataAnnotations;

namespace ApiValidate.Models
{
    public class Parent 
    {
        [Range(1,5)]
        public int MaxCount { get; set; }

        [Count]
        public int Count { get; set; }
       
    }
}
