using System.ComponentModel.DataAnnotations;

namespace ApiValidate.Models
{
    public class MyDateTime : BaseModel 
    {
        public int Id { get; set; }
        
        public DateTime date { get; set; }
    }
}
