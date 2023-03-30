using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace NewMVC.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public DateTime PwLastSet { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
