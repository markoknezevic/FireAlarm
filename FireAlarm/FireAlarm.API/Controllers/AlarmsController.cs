using FireAlarm.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FireAlarm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlarmsController :  BaseController<AlarmsController>
    {
        protected AlarmsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}