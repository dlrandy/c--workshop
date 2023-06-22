using Microsoft.AspNetCore.Mvc;
using exer9.Models;
namespace exer9.Services;
public interface IWeatherForecastService
{
    public WeatherForecast GetWeekday(int day);
    void SaveWeatherForecast(WeatherForecast forecast);
    WeatherForecast GetWeatherForecast(DateTime date);
}
