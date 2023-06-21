using exer9.Services;
using exer9.Providers;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddMemoryCache();
// static WeatherForecastServiceV2 BuildWeatherForecastService(IServiceProvider _){
//     // _.GetService<ServiceType>
//     return new WeatherForecastServiceV2("New York", 4);
// }
builder.Services.AddSingleton<ICurrentTimeProvider, CurrentTimeUtcProvider>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg =>
 {
     var xmlFile = $"{Assembly.GetExecutingAssembly().
    GetName().Name}.xml";
     var xmlPath = Path.Combine(AppContext.BaseDirectory,
    xmlFile);
     cfg.IncludeXmlComments(xmlPath);
 });
// builder.Services.AddLogging(builder => {
//     builder.ClearProviders();
//     builder.AddConsole();
//     builder.AddDebug();

// });
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
