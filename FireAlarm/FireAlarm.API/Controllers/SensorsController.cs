using FireAlarm.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FireAlarm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : BaseController<SensorsController>
    {
        protected SensorsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        
    }
}