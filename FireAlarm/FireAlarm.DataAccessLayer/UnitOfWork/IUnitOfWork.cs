using System.Threading.Tasks;
using FireAlarm.DataAccessLayer.Repositories.Alarms;
using FireAlarm.DataAccessLayer.Repositories.Sensors;
using FireAlarm.DataAccessLayer.Repositories.Statuses;
using FireAlarm.DataAccessLayer.Repositories.Temperatures;

namespace FireAlarm.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStatusesRepository StatusesRepository { get; }
        ISensorsRepository SensorsRepository { get; }
        IAlarmsRepository AlarmsRepository { get; }
        ITemperaturesRepository TemperaturesRepository { get; }

        Task SaveChangesAsync();

        void SaveChanges();

        void Dispose();
    }
}