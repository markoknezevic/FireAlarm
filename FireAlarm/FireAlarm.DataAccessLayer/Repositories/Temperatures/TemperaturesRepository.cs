using FireAlarm.Data;
using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories.Temperatures
{
    public class TemperaturesRepository : Repository<Temperature, long>, ITemperaturesRepository
    {
        private readonly FireAlarmDbContext _fireAlarmDbContext;
        
        public TemperaturesRepository(FireAlarmDbContext fireAlarmDbContext) : base(fireAlarmDbContext)
        {
            _fireAlarmDbContext = fireAlarmDbContext;
        }
    }
}