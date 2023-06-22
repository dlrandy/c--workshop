using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace exer9.Bootstrap;
public static class SwaggerSetup
{
    public static IServiceCollection AddSwagger(this
   IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(cfg =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().
    GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory,
    xmlFile);
            cfg.IncludeXmlComments(xmlPath);
        });
        return services;
    }
}