using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FireAlarm.API.Models
{
    public class AddSensorPostObject
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [Required]
        [JsonProperty("trigger_temperature")]
        public double TriggerTemperature { get; set; }
        
        [JsonProperty("user_email")]
        public string UserEmail { get; set; }
    }
}