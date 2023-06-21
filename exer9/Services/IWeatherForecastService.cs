using Microsoft.AspNetCore.Mvc;

namespace exer9.Services;
public interface IWeatherForecastService
{
    public WeatherForecast GetWeekday(int day);
    void SaveWeatherForecast(WeatherForecast forecast);
    WeatherForecast GetWeatherForecast(DateTime date);
}
