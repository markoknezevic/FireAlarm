using FireAlarm.Data;
using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories.Alarms
{
    public class AlarmsRepository : Repository<Alarm, long>, IAlarmsRepository
    {
        private readonly FireAlarmDbContext _fireAlarmDbContext;
        
        public AlarmsRepository(FireAlarmDbContext fireAlarmDbContext) : base(fireAlarmDbContext)
        {
            _fireAlarmDbContext = fireAlarmDbContext;
        }
    }
}