using Area.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Area.Controllers
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

        public IActionResult Query()
        {
            return View();
        }

        [HttpPost("upload")]
        //[DisableFormValueModelBinding]
        public async Task<IActionResult> Upload()
        {
            Console.WriteLine(HttpContext.Request.Form);

            return StatusCode(202, new { test = "bruh" });
        }

        public IActionResult Test()
        {
            CarForm car = new CarForm();
            return View(car);
        }

        [HttpPost]
        public IActionResult Test([FromBody]CarForm model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult Query(QueryInfoModel model)
        {
            StaffInfoModel staff = new StaffInfoModel();
            staff.workNum = "1010101010";

            Console.WriteLine(staff.workNum);

            return View("Index", staff);
        }

        public IActionResult Privacy()
        {
            TestModel test = new TestModel();
            test.users = new List<User>()
            {
                new User()
                {
                    Id = 1
                },
                new User()
                {
                    Id = 2
                },
                new User()
                {
                    Id = 3
                },
                new User()
                {
                    Id = 4
                },
                new User()
                {
                    Id = 5
                }
            };
           

            return View(test);
        }

        [HttpPost]
        public IActionResult Privacy(TestModel model)
        {
            return RedirectToAction("privacy");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}