using Microsoft.AspNetCore.Mvc;

namespace SporC.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
