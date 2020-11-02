using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExerciseTracker.DataAccessLayer.Repositories.Exercises;
using ExerciseTracker.DataAccessLayer.Repositories.ExerciseWorkouts;
using ExerciseTracker.DataAccessLayer.Repositories.Statuses;
using ExerciseTracker.DataAccessLayer.Repositories.Users;
using ExerciseTracker.DataAccessLayer.Repositories.UserWeights;
using ExerciseTracker.DataAccessLayer.Repositories.WorkoutRecords;
using ExerciseTracker.DataAccessLayer.Repositories.Workouts;

namespace FireAlarm.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IExercisesRepository ExercisesRepository { get; }

        Task SaveChangesAsync();

        void SaveChanges();

        void Dispose();
    }
}