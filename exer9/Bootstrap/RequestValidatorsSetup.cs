using exer9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation.AspNetCore;
namespace exer9.Bootstrap;
using exer9.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
public static class RequestValidatorsSetup
{
    public static IServiceCollection AddRequestValidators(this
   IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<WeatherForecastValidator>();
       return services;
    }
}