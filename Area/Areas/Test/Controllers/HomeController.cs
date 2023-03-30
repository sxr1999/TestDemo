using Microsoft.AspNetCore.Mvc;

namespace Area.Areas.Test.Controllers
{
    [Area("Test")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
