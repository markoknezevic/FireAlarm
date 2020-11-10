using System.Threading.Tasks;
using FireAlarm.Data;
using FireAlarm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireAlarm.DataAccessLayer.Repositories.Sensors
{
    public class SensorsRepository : Repository<Sensor, long>, ISensorsRepository
    {
        private readonly FireAlarmDbContext _fireAlarmDbContext;
        
        public SensorsRepository(FireAlarmDbContext fireAlarmDbContext) : base(fireAlarmDbContext)
        {
            _fireAlarmDbContext = fireAlarmDbContext;
        }
        
        public async Task<Sensor> GetSensorByIdAsync(long? sensorId)
        {
            var sensor = await _fireAlarmDbContext.Sensors.FirstOrDefaultAsync((s => s.Id == sensorId));

            return sensor;
        }
    }
}