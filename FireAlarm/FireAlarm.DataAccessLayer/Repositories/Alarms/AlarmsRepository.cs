using System.Threading.Tasks;
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

        public async Task<bool> CreateAlarm(Alarm alarm)
        {
            await _fireAlarmDbContext.Alarms.AddAsync(alarm);
            var result = await _fireAlarmDbContext.SaveChangesAsync();
            
            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}