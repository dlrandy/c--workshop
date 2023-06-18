using Microsoft.AspNetCore.Mvc;
using exer9.Providers;
namespace exer9.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrentTimeController : ControllerBase
{
 
    private readonly ILogger<CurrentTimeController> _logger;
    private readonly ICurrentTimeProvider _currentTimeProvider;

    public CurrentTimeController(ILogger<CurrentTimeController> logger,
    ICurrentTimeProvider currentTimeProvider
    )
    {
        _logger = logger;
        _currentTimeProvider = currentTimeProvider;
    }


    [HttpGet("current")]
    public IActionResult Get(string timezoneId){
        var time = _currentTimeProvider.GetTime(timezoneId);
        return Ok(time);
    }
}
