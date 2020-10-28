using Microsoft.AspNetCore.Mvc;

namespace OneTimePassword.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        //
        // Summary:
        //     /// Method responsible for redirect to swagger page. ///
        //
        [Route("")]
        [HttpGet]
        public IActionResult Index() => Redirect("/swagger");
    }
}
