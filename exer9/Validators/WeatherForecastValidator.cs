using System;
using exer9.Models;
using FluentValidation;

namespace exer9.Validators;
public class WeatherForecastValidator:AbstractValidator<WeatherForecast>
{
    public WeatherForecastValidator(){
        RuleFor(p => p.Date)
            .LessThan(DateTime.Now.AddMonths(1))
            .WithMessage("Weather forecasts in more than 1 month of future are not supported");

        RuleFor(p => p.TemperatureC)
            .InclusiveBetween(-100, 100)
            .WithMessage("A temperature must be between -100 and +100 C.");

    }
}