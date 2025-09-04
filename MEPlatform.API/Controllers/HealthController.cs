using Microsoft.AspNetCore.Mvc;

namespace MEPlatform.API.Controllers;

[ApiController]
[Route("")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { 
            message = "MEPlatform API is running successfully!",
            timestamp = DateTime.UtcNow,
            version = "1.0.0",
            swagger = "/swagger"
        });
    }
    
    [HttpGet("health")]
    public IActionResult Health()
    {
        return Ok(new { 
            status = "healthy",
            timestamp = DateTime.UtcNow 
        });
    }
}