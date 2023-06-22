using Microsoft.AspNetCore.Mvc;
using exer9.Services;
using exer9.Exceptions;
using exer9.Models;
namespace exer9.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService1;
    private readonly IWeatherForecastService _weatherForecastService2;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
    IWeatherForecastService weatherForecastService1,
    IWeatherForecastService weatherForecastService2
    )
    {
        _logger = logger;
        _weatherForecastService1 = weatherForecastService1;
        _weatherForecastService2 = weatherForecastService2;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet("error")]
    public IEnumerable<WeatherForecast> GetError()
    {
        _logger.LogError("Whoops");
        throw new Exception("Something went wrong");
    }

    [HttpGet("weekday/{day}")]
    public IActionResult GetWeekDay(int day)
    {
        // try
        // {
            var result = _weatherForecastService1.GetWeekday(day);
            result = _weatherForecastService2.GetWeekday(day);
            return Ok(result);
        // }
        // catch (NoSuchWeekdayException exception)
        // {
        //     return NotFound(exception.Message);
        // }
    }

    /// <summary>
            /// Gets weather forecast at a specified date.
    /// </summary>
    /// <param name="date">Date of a forecast.</param>
    /// <returns>
            /// A forecast at a specified date.
    /// If not found - 404.
    /// </returns>
    [HttpGet("{date}")]
    public IActionResult GetWeatherForecast(DateTime date, string query)
    {
        System.Console.WriteLine($"query:{query}");
        var weatherForecast = _weatherForecastService1.GetWeatherForecast(date);
        if (weatherForecast == null)
        {
            return NotFound();
        }
        return Ok(weatherForecast);
    }
    /// <summary>
    /// Saves a forecast at forecast date.
    /// </summary>
    /// <param name="weatherForecast">Date which identifies a forecast.Using short date time string for identity.</param>
    /// <returns>201 with a link to an action to fetch a created forecast.</returns>
    [HttpPost]
    public IActionResult SaveWeatherForecast(WeatherForecast weatherForecast)
    {
        _weatherForecastService1.SaveWeatherForecast(weatherForecast);
        return CreatedAtAction("GetWeatherForecast", new
        {
            date = weatherForecast.Date.ToShortDateString()
        }, weatherForecast);
    }
}
