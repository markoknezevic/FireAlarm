using System.Threading.Tasks;
using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories.Alarms
{
    public interface IAlarmsRepository : IRepository<Alarm, long>
    {
        Task<bool> CreateAlarm(Alarm alarm);
    }
}