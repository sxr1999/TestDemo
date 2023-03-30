namespace NewMVC.Models
{
    public class Employees
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Photo { get; set; }
    }
}
