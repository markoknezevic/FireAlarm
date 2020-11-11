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
        public SensorsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        [HttpPatch("{sensorId}")]
        public async Task<ActionResult> Patch(long sensorId)
        {
            var result = await UnitOfWork.SensorsRepository.ActivateSensorAsync(sensorId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}