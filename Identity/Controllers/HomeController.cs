using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<WebApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<WebApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result  = await _userManager.Users.Include(x=>x.Favorites).Where(x=>x.Id== HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}