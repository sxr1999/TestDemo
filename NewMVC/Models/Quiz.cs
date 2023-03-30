using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Quiz
    {
        [Key]
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>() { };
    }
}
