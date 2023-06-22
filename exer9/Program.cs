
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using exer9.Bootstrap;
using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.Caching.Memory;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// static WeatherForecastServiceV2 BuildWeatherForecastService(IServiceProvider _){
//     // _.GetService<ServiceType>
//     return new WeatherForecastServiceV2("New York", 4);
// }


builder.Services
.AddControllersConfiguration()
.AddLoggingConfiguration()
 .AddRequestValidators()
 .AddSwagger()
.AddWeatherService(builder.Configuration)
 .AddExceptionMappings(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
    app.UseDeveloperExceptionPage();
}

app.UseProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
