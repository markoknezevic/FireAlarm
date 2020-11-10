using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FireAlarm.API.Models
{
    public class AddTemperaturePostObject
    {
        
        [Required]
        [JsonProperty("value")]
        public double? Value { get; set; }
        
        [Required]
        [JsonProperty("key")]
        public long? Key { get; set; }
    }
}