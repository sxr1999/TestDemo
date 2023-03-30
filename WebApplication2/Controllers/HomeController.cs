using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly UserManager<UserInformation> _userManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_userManager = userManager;
        }

        List<Templates> templates = new List<Templates> {
            new Templates
            {
                Item1 = "Test1",
                Item2 = "AAA"
            },
            new Templates
            {
                Item1 = "Test2",
                Item2 = "BBB"
            },
            new Templates
            {
                Item1 = "Test3",
                Item2 = "CCC"
            },
            new Templates
            {
                Item1 = "Test4",
                Item2 = "DDD"
            },
            new Templates
            {
                Item1 = "Test5",
                Item2 = "EEE"
            },
            new Templates
            {
                Item1 = "Test6",
                Item2 = "FFF"
            }

        };

        public IActionResult Index()
        {
            
            return View(templates);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}