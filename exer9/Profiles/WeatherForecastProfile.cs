using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using exer9.Dtos;

namespace exer9.Profiles
{
 public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<Dtos.WeatherForecast, Models.WeatherForecast>()
                .ForMember(to => to.DateTime, opt => opt.MapFrom(from => from.DateTime))
                .ForMember(to => to.Summary, opt => opt.MapFrom(from => from.Conditions))
                .ForMember(to => to.TemperatureC, opt => opt.MapFrom(from => (int)double.Parse(from.Temperature, CultureInfo.InvariantCulture)));
        }
    }
}