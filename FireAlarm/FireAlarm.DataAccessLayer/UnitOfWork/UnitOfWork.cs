using System.Threading.Tasks;
using ExerciseTracker.DataAccessLayer.Repositories.Exercises;
using FireAlarm.Data;

namespace FireAlarm.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FireAlarmDbContext _fireAlarmDbContext;

        public UnitOfWork(FireAlarmDbContext exerciseTrackerDbContext)
        {
            _fireAlarmDbContext = exerciseTrackerDbContext;
        }


        private IExercisesRepository _exercisesRepository;
        public IExercisesRepository ExercisesRepository => this._exercisesRepository ??
                                                           (this._exercisesRepository =
                                                               new ExercisesRepository(_fireAlarmDbContext));
        
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