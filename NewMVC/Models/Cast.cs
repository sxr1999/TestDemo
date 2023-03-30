using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewMVC.Models
{
    public class Cast
    {
        [JsonProperty("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CastId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        public long ShowId { get; set; }
        public ICollection<Show> Show { get; set; }
    }
}
