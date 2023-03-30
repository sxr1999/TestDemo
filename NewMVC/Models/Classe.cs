using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Classe
    {
        [Key]
        public int Id_class { get; set; }
        public string ClassName { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
