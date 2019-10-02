using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class Launchpad {
        
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("full_name")]
        public string Name { get; set;}

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}