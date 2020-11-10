using System.Threading.Tasks;
using AutoMapper;
using FireAlarm.API.DTOs;
using FireAlarm.API.Models;
using FireAlarm.Data.Entities;
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