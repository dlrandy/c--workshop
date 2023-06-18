using Microsoft.AspNetCore.Mvc;

namespace exer9.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeController : ControllerBase
{
 
    private readonly ILogger<TimeController> _logger;

    public TimeController(ILogger<TimeController> logger)
    {
        _logger = logger;
    }


    [HttpGet("current")]
    public IActionResult GetCurrentTime(){
        return Ok(DateTime.Now.ToString("o"));
    }
}
