using NewMVC.Migrations;

namespace NewMVC.Models
{
    public class City
    {
        // this Id is stored in Service B's DB as ItemId
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Object Location { get; set; }
    }
}
