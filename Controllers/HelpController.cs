using Microsoft.AspNetCore.Mvc;

namespace Moview.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
