using exer9.Dtos;
public interface IWeatherForecastProvider
 {
 Task<WeatherForecast> GetCurrent(string location);
 }