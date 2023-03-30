namespace NewMVC.Models
{
    public class TestA
    {
        public List<string> Test { get; set; }
        public List<TestB> testb { get; set; } = new List<TestB>();
    }
}
