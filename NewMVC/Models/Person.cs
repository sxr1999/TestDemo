using Newtonsoft.Json;

namespace NewMVC.Models
{
    public class Person
    {
        [JsonProperty("person")]
        public CastTemp castTemp { get; set; }
    }
}
