

using FireAlarm.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FireAlarm.API.Controllers
{
    public class BaseController<TController> : ControllerBase where TController : ControllerBase
    {
        protected IUnitOfWork UnitOfWork;

        protected BaseController(IUnitOfWork unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
        }
    }
}