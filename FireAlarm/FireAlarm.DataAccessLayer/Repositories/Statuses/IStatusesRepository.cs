using System.Collections.Generic;
using System.Threading.Tasks;
using FireAlarm.Data.Entities;
using FireAlarm.DataAccessLayer.Repositories;

namespace FireAlarm.DataAccessLayer.Repositories.Statuses
{
    public interface IStatusesRepository : IRepository<Status, short>
    {
        Task<List<Status>> GetAllStatusesAsync();

        List<Status> GetAllStatuses();
    }
}