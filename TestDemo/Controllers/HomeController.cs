using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestDemo.Models;

namespace TestDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            StaffInfoModel staff = new StaffInfoModel();
            staff.workNum = "1010101010";

            return View("Index", staff);
        }

        public IActionResult Query()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Query(QueryInfoModel model)
        {
            StaffInfoModel staff = new StaffInfoModel();
            staff.workNum = "1010101010";

            Debug.WriteLine(staff.workNum);

            return View("Index", staff);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}