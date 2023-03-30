using System.ComponentModel.DataAnnotations.Schema;

namespace NewMVC.Models
{
    public class Subject
    {   
            public int Id { get; set; }
            public string SubjectName { get; set; }
            [NotMapped]
            public virtual Classe Classe { get; set; }
        
    }
}
