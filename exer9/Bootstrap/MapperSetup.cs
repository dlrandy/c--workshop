using exer9.Profiles;
public static class MapperSetup
{
    public static IServiceCollection AddModelMappings(this
   IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<WeatherForecastProfile>();
        });
        return services;
    }
}