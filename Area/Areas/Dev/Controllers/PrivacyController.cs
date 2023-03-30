using Microsoft.AspNetCore.Mvc;

namespace Area.Areas.Dev.Controllers
{
    [Area("Dev")]
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
