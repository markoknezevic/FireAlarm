using FireAlarm.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FireAlarm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : BaseController<TemperatureController>
    {
        protected TemperatureController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}