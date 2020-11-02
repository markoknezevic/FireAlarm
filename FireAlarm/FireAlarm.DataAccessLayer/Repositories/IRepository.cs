using FireAlarm.Data.Entities;

namespace FireAlarm.DataAccessLayer.Repositories
{
    public interface IRepository <T, TK> where T : Entity<TK> where TK : struct
    {
        
    }
}