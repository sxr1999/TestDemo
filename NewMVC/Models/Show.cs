using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NewMVC.Models
{
    public class Show
    {
        [JsonProperty("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ShowId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public ICollection<Cast> Casts { get; set; }
    }
}
