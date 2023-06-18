using Microsoft.AspNetCore.Mvc;
using exer9.Exceptions;
namespace exer9.Services;

public class WeatherForecastService:IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    public WeatherForecastService(ILogger logger){
        _logger = logger;
        _logger.LogInformation(Guid.NewGuid().ToString());
    }
    public WeatherForecast GetWeekday(int day){
        if (day < 1 || day > 7)
        {
            throw new NoSuchWeekdayException(day);
        }
        return new WeatherForecast();
    }
}
public class WeatherForecastServiceV2 : IWeatherForecastService
{
 private readonly string _city;
 private readonly int _refreshInterval;
 public WeatherForecastService(string city, int refreshInterval)
 {
 _city = city;
 _refreshInterval = refreshInterval;
 }
    public WeatherForecast GetWeekday(int day){
        if (day < 1 || day > 7)
        {
            throw new NoSuchWeekdayException(day);
        }
        return new WeatherForecast();
    }
}
