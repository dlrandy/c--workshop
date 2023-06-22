using Microsoft.AspNetCore.Mvc;
using exer9.Exceptions;
using exer9.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
namespace exer9.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    private readonly string _city;
    private readonly int _refreshInterval;
    private readonly Guid _serviceIdentifier;
    private readonly IMemoryCache _cache;
    public WeatherForecastService(ILogger<WeatherForecastService> logger,
    IOptions<WeatherForecastConfig> config,
   IMemoryCache cache)
    {
        _logger = logger;
        _logger.LogInformation(Guid.NewGuid().ToString());
        _city = "XXX";
        _refreshInterval = 10;
        _serviceIdentifier = Guid.NewGuid();
        _cache = cache;
    }
    public WeatherForecast GetWeekday(int day)
    {
        if (day < 1 || day > 7)
        {
            throw new NoSuchWeekdayException(day);
        }
        return new WeatherForecast();
    }
    public void SaveWeatherForecast(WeatherForecast forecast)
    {
        _cache.Set(forecast.Date.ToShortDateString(), forecast);
    }
    public WeatherForecast GetWeatherForecast(DateTime date){
        var shortDateString = date.ToShortDateString();
        var contains = _cache.TryGetValue(shortDateString, out var entry);
        return !contains ? null : (WeatherForecast)entry;
    }
}
public class WeatherForecastServiceV2 : IWeatherForecastService
{
    private readonly string _city;
    private readonly int _refreshInterval;
    private readonly Guid _serviceIdentifier;
     private readonly ILogger<WeatherForecastServiceV2> _logger;
    private readonly IMemoryCache _cache;
    public WeatherForecastServiceV2(ILogger<WeatherForecastServiceV2> logger,
    string city, int refreshInterval, IMemoryCache cache)
    {
        _logger = logger;
        _logger.LogInformation(Guid.NewGuid().ToString());
        _city = city;
        _refreshInterval = refreshInterval;
        _serviceIdentifier = Guid.NewGuid();
        _cache = cache;
    }
    public WeatherForecast GetWeekday(int day)
    {
        if (day < 1 || day > 7)
        {
            throw new NoSuchWeekdayException(day);
        }
        return new WeatherForecast();
    }
    public void SaveWeatherForecast(WeatherForecast forecast)
    {
        _cache.Set(forecast.Date.ToShortDateString(), forecast);
    }
    public WeatherForecast GetWeatherForecast(DateTime date){
        var shortDateString = date.ToShortDateString();
        var contains = _cache.TryGetValue(shortDateString, out var entry);
        return !contains ? null : (WeatherForecast)entry;
    }
    }

