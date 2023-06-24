using System;
using exer9.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace exer9.Bootstrap
{
    public static class HttpClientsSetup
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IWeatherForecastProvider, WeatherForecastProvider>(client =>
            {
                client.BaseAddress = new Uri(config["WeatherForecastProviderUrl"]);
                var apiKey = config["WeatherForecastProviderKey"];// Environment.GetEnvironmentVariable("x-rapidapi-key", EnvironmentVariableTarget.User);
                client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            });

            return services;
        }
    }
}