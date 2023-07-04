using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TuCarbureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarburantController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CarburantController> _logger;

        public CarburantController(ILogger<CarburantController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetCarburant", Name = "GetCarburant")]
        public IEnumerable<Carburant> GetCarburant()
        {
            return Enumerable.Range(1, 5).Select(index => new Carburant
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
