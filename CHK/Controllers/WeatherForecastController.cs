using CHK.Commands;
using CHK.Common;
using CHK.Infrastructure;
using CHK.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CHK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Sender sender;
        private readonly InfoRepository infoRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Sender sender, ICommandHandler<AddInfoCommand> addInfoCommandHandler)
        {
            _logger = logger;
            this.sender = sender;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            await this.sender.Send(AddInfoCommand.CreateEmpty());
            await this.sender.Send(AddDeviceCommand.CreateEmpty());

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}