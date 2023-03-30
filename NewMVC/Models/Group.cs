using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMVC.Models
{
    public class Group
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GroupType { get; set; }

        public virtual ICollection<User> Members { get; set; }
    }
}
