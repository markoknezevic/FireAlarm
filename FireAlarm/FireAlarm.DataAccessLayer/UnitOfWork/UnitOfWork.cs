using System.Threading.Tasks;
using FireAlarm.Data;
using FireAlarm.DataAccessLayer.Repositories.Alarms;
using FireAlarm.DataAccessLayer.Repositories.Sensors;
using FireAlarm.DataAccessLayer.Repositories.Statuses;
using FireAlarm.DataAccessLayer.Repositories.Temperatures;

namespace FireAlarm.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FireAlarmDbContext _fireAlarmDbContext;

        public UnitOfWork(FireAlarmDbContext exerciseTrackerDbContext)
        {
            _fireAlarmDbContext = exerciseTrackerDbContext;
        }


        private IStatusesRepository _statusesRepository;
        public IStatusesRepository StatusesRepository => this._statusesRepository ??
                                                          (this._statusesRepository =
                                                              new StatusesRepository(_fireAlarmDbContext));
        
        private IAlarmsRepository _alarmsRepository;
        public IAlarmsRepository AlarmsRepository => this._alarmsRepository ??
                                                          (this._alarmsRepository =
                                                              new AlarmsRepository(_fireAlarmDbContext));
        
        private ITemperaturesRepository _temperaturesRepository;
        public ITemperaturesRepository TemperaturesRepository => this._temperaturesRepository ??
                                                           (this._temperaturesRepository =
                                                               new TemperaturesRepository(_fireAlarmDbContext));
        
        
        private ISensorsRepository _sensorsRepository;
        public ISensorsRepository SensorsRepository => this._sensorsRepository ??
                                                                 (this._sensorsRepository =
                                                                     new SensorsRepository(_fireAlarmDbContext));
        
        public Task SaveChangesAsync()
        {
            return _fireAlarmDbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _fireAlarmDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _fireAlarmDbContext.Dispose();
        }
    }
}