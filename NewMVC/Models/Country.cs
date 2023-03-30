namespace NewMVC.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<State> States { get; set; }
    }
}
