using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireAlarm.Data.Entities
{
    public enum Statuses : short
    {
        [DisplayName("Active")] Active = 1,

        [DisplayName("Inactive")] Inactive = 2,
    }

    [Table("statuses")]
    public class Status : TimestampedEntity<short>
    {
        [Key] 
        [Column("id", Order = 1)] 
        public override short Id { get; set; }

        [Required] 
        [Column("name", Order = 2)] 
        public string Name { get; set; }
        
        public ICollection<Sensor> Sensors { get; set; }
    }
}