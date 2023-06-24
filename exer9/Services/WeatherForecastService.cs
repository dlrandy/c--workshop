using Microsoft.AspNetCore.Mvc;
using exer9.Exceptions;
using exer9.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using AutoMapper;
namespace exer9.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    private readonly string _city;
    private readonly int _refreshInterval;
    private readonly Guid _serviceIdentifier;
    private readonly IMemoryCache _cache;
    private readonly IWeatherForecastProvider _provider;
    private readonly IMapper _mapper;
    public WeatherForecastService(ILogger<WeatherForecastService> logger,
    IOptions<WeatherForecastConfig> config,
    IWeatherForecastProvider provider,
    IMapper mapper,
   IMemoryCache cache)
    {
        _logger = logger;
        _logger.LogInformation(Guid.NewGuid().ToString());
        _city = "XXX";
        _refreshInterval = 10;
        _serviceIdentifier = Guid.NewGuid();
        _cache = cache;
        _provider = provider;
        _mapper = mapper;
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
        _cache.Set(forecast.DateTime.ToShortDateString(), forecast);
    }
    public async Task<WeatherForecast> GetWeatherForecast(DateTime date)
    {
        const string DateFormat = "yyyy-MM-ddthh";
        var contains = _cache.TryGetValue(DateTime.UtcNow.ToString(DateFormat), out var entry);
        if (contains) { return (WeatherForecast)entry; }
        var forecastDto = await _provider.GetCurrent(_city);
        var forecast = _mapper.Map<WeatherForecast>(forecastDto);
        forecast.DateTime = DateTime.UtcNow;
        _cache.Set(DateTime.UtcNow.ToString(DateFormat), forecast);
        return forecast;

    }
}
// public class WeatherForecastServiceV2 : IWeatherForecastService
// {
//     private readonly string _city;
//     private readonly int _refreshInterval;
//     private readonly Guid _serviceIdentifier;
//     private readonly ILogger<WeatherForecastServiceV2> _logger;
//     private readonly IMemoryCache _cache;
//     public WeatherForecastServiceV2(ILogger<WeatherForecastServiceV2> logger,
//     string city, int refreshInterval, IMemoryCache cache)
//     {
//         _logger = logger;
//         _logger.LogInformation(Guid.NewGuid().ToString());
//         _city = city;
//         _refreshInterval = refreshInterval;
//         _serviceIdentifier = Guid.NewGuid();
//         _cache = cache;
//     }
//     public WeatherForecast GetWeekday(int day)
//     {
//         if (day < 1 || day > 7)
//         {
//             throw new NoSuchWeekdayException(day);
//         }
//         return new WeatherForecast();
//     }
//     public void SaveWeatherForecast(WeatherForecast forecast)
//     {
//         _cache.Set(forecast.Date.ToShortDateString(), forecast);
//     }
//     public WeatherForecast GetWeatherForecast(DateTime date)
//     {
//         var shortDateString = date.ToShortDateString();
//         var contains = _cache.TryGetValue(shortDateString, out var entry);
//         return !contains ? null : (WeatherForecast)entry;
//     }
// }

