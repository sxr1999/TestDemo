using Microsoft.AspNetCore.Mvc;

namespace NewMVC.Area.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
