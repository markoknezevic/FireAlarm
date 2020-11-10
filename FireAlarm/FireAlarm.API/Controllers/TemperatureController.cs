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
    public class TemperatureController : BaseController<TemperatureController>
    {
        public TemperatureController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        public async Task<ActionResult> Post([FromBody] AddTemperaturePostObject addTemperaturePostObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var sensor = await UnitOfWork.SensorsRepository.GetSensorByIdAsync(addTemperaturePostObject.Key);
            if (sensor == null)
            {
                return BadRequest();
            }


            if (addTemperaturePostObject.Value > sensor.TriggerTemperature)
            {
                // TODO: Trigger email
            }
            var result = await UnitOfWork.TemperaturesRepository.AddTemperatureAsync(new Temperature()
            {
                SensorId = addTemperaturePostObject.Key.Value,
                TemperatureValue = addTemperaturePostObject.Value.Value
            });

            if (!result)
            {
                return BadRequest();
            }

            return Created(string.Empty,null);
        }
    }
}