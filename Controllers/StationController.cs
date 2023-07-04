using Microsoft.AspNetCore.Mvc;

namespace TuCarbureAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StationController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<StationController> _logger;

    public StationController(ILogger<StationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetStation")]
    public IEnumerable<Station> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Station
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
