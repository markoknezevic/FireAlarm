using System;

namespace FireAlarm.Data
{
    public interface ITimestampable
    {
        DateTime CreatedAt { get; set; }
        
        DateTime UpdatedAt { get; set; }
    }
}