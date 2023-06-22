using exer9.Exceptions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace exer9.Bootstrap;
public static class ExceptionMappingSetup
{
    public static IServiceCollection AddExceptionMappings(this
   IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddProblemDetails(opt =>
     {
         // https://github.com/khellang/Middleware/blob/master/samples/ProblemDetails.MinimalApiSample/Program.cs
         opt.IncludeExceptionDetails = (context, exception) => builder.Environment.IsDevelopment();
         opt.MapToStatusCode<NoSuchWeekdayException>(StatusCodes.Status404NotFound);
         // opt.Map<NoSuchWeekdayException>(ex => new ProblemDetails
         // {
         //     Title = "Could not find day",
         //     Status = StatusCodes.Status404NotFound,
         //     Detail = ex.Message,
         // });
     });
     return services;
    }
}