using Microsoft.AspNetCore.Mvc;

namespace EMSI.Airbook.WebAPI.Controllers;

public class ControllerBase : Controller
{
    protected IActionResult OkEncapsulated<T>(T result, int? totalItems = null)
    {
        return Ok(new 
        {
            Result = result,
            TotalItems = totalItems
        });
    }
    
    protected IActionResult Forbidden(object? obj = null)
    {
        return StatusCode(StatusCodes.Status403Forbidden, obj);
    }

    protected IActionResult FailedDependency()
    {
        return StatusCode(StatusCodes.Status424FailedDependency);
    }
    
    protected IActionResult Gone()
    {
        return StatusCode(StatusCodes.Status410Gone);
    }
    
    protected IActionResult CreatedNoPayload()
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}