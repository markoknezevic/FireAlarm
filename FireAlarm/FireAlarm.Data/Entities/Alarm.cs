using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireAlarm.Data.Entities
{
    [Table("alarms")]
    public class Alarm : TimestampedEntity<long>
    {
        [Key] 
        [Column("id", Order = 1)] 
        public override long Id { get; set; }
        
        [Required] 
        [Column("temperature_value", Order = 2)] 
        public double TemperatureValue { get; set; }
        
        [Required]
        [Column("sensor_id", Order = 3)]
        public long SensorId { get; set; }
        
        [ForeignKey("SensorId")]
        public Sensor Sensor { get; set; }
        
    }
}