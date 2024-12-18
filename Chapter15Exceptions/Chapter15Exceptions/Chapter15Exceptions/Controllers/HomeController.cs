using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Chapter15Exceptions.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet(Name = "Get")]
    public IActionResult Error()
    {
        var exceptionDetails = HttpContext.Features.Get
            <IExceptionHandlerPathFeature>();
        if (exceptionDetails != null)
        {
            // Log details of error
            Log.Error(exceptionDetails.Error,
                "An error occurred at path {Path}"
                , exceptionDetails.Path);
        }
        return View();
    }
}
