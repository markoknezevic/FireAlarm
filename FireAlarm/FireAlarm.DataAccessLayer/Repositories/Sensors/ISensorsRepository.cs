using System.Threading.Tasks;
using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories.Sensors
{
    public interface ISensorsRepository : IRepository<Sensor, long>
    {
        Task<Sensor> GetSensorByIdAsync(long? sensorId);
    }
}