namespace NewMVC.Models
{
    public class ClassA
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public List<SubClassA> subClassA { get; set; }
    }
}
