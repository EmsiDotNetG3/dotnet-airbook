using Microsoft.AspNetCore.Mvc;

namespace EMSI.Airbook.WebAPI.Controllers;

[Route("[controller]")]
public class InfoController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return OkEncapsulated(new
        {
            AppName = "Airbook",
            AppVersion = "1.0.0",
            AppDescription = "A flight booking application",
            CurrentUtcDateTime = DateTime.UtcNow,
            TechnologyStack = new[] { "ASP.NET Core", "Entity Framework Core", "Docker" }
        });
    }
}