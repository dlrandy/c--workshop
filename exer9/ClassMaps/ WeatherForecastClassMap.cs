using exer9.Dtos;
namespace exer9.ClassMaps;
using CsvHelper.Configuration;
public class WeatherForecastClassMap : ClassMap<WeatherForecast>
{
    public WeatherForecastClassMap()
    {
        Map(m => m.DateTime).Name("Date time");
        Map(m => m.Temperature).Name("Temperature");
        Map(m => m.Conditions).Name("Conditions");
    }
}