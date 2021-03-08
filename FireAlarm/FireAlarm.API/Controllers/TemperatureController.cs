using System.Threading.Tasks;
using AutoMapper;
using FireAlarm.API.DTOs;
using FireAlarm.API.Helpers;
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
        private readonly MailSender _mailSender;

        public TemperatureController(IUnitOfWork unitOfWork, MailSender mailSender) : base(unitOfWork)
        {
            _mailSender = mailSender;
        }
        
        [HttpPost]
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
                await UnitOfWork.AlarmsRepository.CreateAlarm(new Alarm()
                {
                    TemperatureValue = addTemperaturePostObject.Value.Value,
                    SensorId = sensor.Id
                });
                
                await UnitOfWork.SensorsRepository.DeactivateSensorAsync(sensor.Id);
                
                _mailSender.SendEmail(sensor.UserEmail, sensor.Name, addTemperaturePostObject.Value);
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