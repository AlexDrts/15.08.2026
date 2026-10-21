using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class ErrorController : Controller
    {
        // Сюди перенаправляє UseStatusCodePagesWithReExecute
        [Route("Error/{code}")]
        public IActionResult Index(int code)
        {
            Response.StatusCode = code;
            return View("NotFound");
        }
    }
}
