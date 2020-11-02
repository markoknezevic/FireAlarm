using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireAlarm.Data.Entities
{
    [Table("sensors")]
    public class Sensor : TimestampedEntity<long>
    {
        [Key] 
        [Column("id", Order = 1)] 
        public override long Id { get; set; }
        
        [Required] 
        [Column("name", Order = 2)] 
        public string Name { get; set; }
        
        [Required] 
        [Column("trigger_temperature", Order = 3)] 
        public double TriggerTemperature { get; set; }
        
        [Required]
        [Column("status_id", Order = 4)]
        public short StatusId { get; set; }
        
        [Required]
        [Column("user_email", Order = 5)]
        public string UserEmail { get; set; }
        
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        
        public ICollection<Alarm> Alarms { get; set; }
        
        public ICollection<Temperature> Temperatures { get; set; }
    }
}