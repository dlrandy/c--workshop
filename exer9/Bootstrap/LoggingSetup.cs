using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace exer9.Bootstrap;
public static class LoggingSetup
{
    public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services){
        services.AddLogging(builder =>{
            builder.ClearProviders();
            builder.AddConsole();
            builder.AddDebug();
        });

        return services;
    }
}