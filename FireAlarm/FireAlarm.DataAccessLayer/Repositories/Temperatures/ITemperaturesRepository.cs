using System.Threading.Tasks;
using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories.Temperatures
{
    public interface ITemperaturesRepository : IRepository<Temperature, long>
    {
        Task<bool> AddTemperatureAsync(Temperature temperature);
    }
}