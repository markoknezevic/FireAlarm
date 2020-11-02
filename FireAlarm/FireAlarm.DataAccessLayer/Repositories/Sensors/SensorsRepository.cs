using FireAlarm.Data;
using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories.Sensors
{
    public class SensorsRepository : Repository<Sensor, long>, ISensorsRepository
    {
        private readonly FireAlarmDbContext _fireAlarmDbContext;
        
        public SensorsRepository(FireAlarmDbContext fireAlarmDbContext) : base(fireAlarmDbContext)
        {
            _fireAlarmDbContext = fireAlarmDbContext;
        }
    }
}