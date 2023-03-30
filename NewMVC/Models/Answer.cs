using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Answer
    {
        [Key]
        public Guid Id { get; } = Guid.NewGuid();
        public string Content { get; set; }
        public Guid QuestionId { get; set; }
    }
}
