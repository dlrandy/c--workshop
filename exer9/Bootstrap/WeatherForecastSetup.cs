using exer9.Services;
using exer9.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using Microsoft.Extensions.Options;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace exer9.Bootstrap;
public static class WeatherServiceSetup
{
    public static IServiceCollection AddWeatherService(this
   IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IWeatherForecastService,
       WeatherForecastService>(BuildWeatherForecastService);
        services.AddSingleton<ICurrentTimeProvider,
       CurrentTimeUtcProvider>();
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.Configure<WeatherForecastConfig>(configuration.
        GetSection(nameof(WeatherForecastConfig)));
        return services;
    }
    private static WeatherForecastService
   BuildWeatherForecastService(IServiceProvider provider)
    {
        var logger = provider
        .GetService<ILoggerFactory>().CreateLogger<WeatherForecastService>();
        var options = provider.
       GetService<IOptions<WeatherForecastConfig>>();
        return new WeatherForecastService(logger, options, provider.
       GetService<IMemoryCache>());
    }
}