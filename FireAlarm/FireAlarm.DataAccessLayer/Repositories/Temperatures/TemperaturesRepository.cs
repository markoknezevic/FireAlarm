using System.Threading.Tasks;
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

        public async Task<bool> AddTemperatureAsync(Temperature temperature)
        {
            await _fireAlarmDbContext.Temperatures.AddAsync(temperature);
            var result = await _fireAlarmDbContext.SaveChangesAsync();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}