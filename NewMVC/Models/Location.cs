using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public Floors Floor { get; set; }
            
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public Equipment equipment { get; set; }

        [Required]
        public string Row { get; set; }
    }
}
