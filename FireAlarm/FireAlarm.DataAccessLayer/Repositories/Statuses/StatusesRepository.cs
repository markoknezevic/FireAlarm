using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireAlarm.Data;
using FireAlarm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireAlarm.DataAccessLayer.Repositories.Statuses
{
    public class StatusesRepository : Repository<Status, short>, IStatusesRepository
    {
        private readonly FireAlarmDbContext _fireAlarmDbContext;
        
        public StatusesRepository(FireAlarmDbContext fireAlarmDbContext) : base(fireAlarmDbContext)
        {
            _fireAlarmDbContext = fireAlarmDbContext;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            var statuses = await _fireAlarmDbContext.Statuses.ToListAsync();

            return statuses;
        }

        public List<Status> GetAllStatuses()
        {
            var statuses = _fireAlarmDbContext.Statuses.ToList();

            return statuses;
        }
    }
}