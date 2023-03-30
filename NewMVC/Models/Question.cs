using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; } = Guid.NewGuid();
        public string Content { get; set; }
        public Guid QuizId { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>() {
        new Answer() { Content = "Answeeeer" },
        new Answer() { Content = "Answeeeer2" },
        new Answer() { Content = "Answeeeer3" }
    };
    }
}
