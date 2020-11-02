using FireAlarm.Data;
using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories
{
    public class Repository <T, TK> : IRepository<T, TK> where T : Entity<TK> where TK : struct
    {
        private FireAlarmDbContext _fireAlarmDbContext;

        public Repository(FireAlarmDbContext fireAlarmDbContext)
        {
            _fireAlarmDbContext = fireAlarmDbContext;
        }
    }
}