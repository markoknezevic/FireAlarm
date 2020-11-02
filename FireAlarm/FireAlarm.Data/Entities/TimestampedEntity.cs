using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireAlarm.Data.Entities
{
    public abstract class TimestampedEntity<T> : Entity<T>, ITimestampable where T : struct
    {
        [Required] [Column("created_at")] public DateTime CreatedAt { get; set; }

        [Column("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}