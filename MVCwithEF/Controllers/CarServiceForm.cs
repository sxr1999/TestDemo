using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCwithEF.Models;
using MVCwithEF.MyDbContext;
using System.Reflection.Metadata.Ecma335;

namespace MVCwithEF.Controllers
{
    public class CarServiceForm : Controller
    {
        private readonly SchoolContext _context;
        public CarServiceForm(SchoolContext context)
        {
            _context = context;
        }

       
        List<SelectListItem> selectListItems = new List<SelectListItem>()
        {
           new SelectListItem{ Value = "Mr", Text = "Mr"},
            new SelectListItem{ Value = "Mrs", Text = "Mrs"},
            new SelectListItem{ Value = "Miss", Text = "Miss"},
            new SelectListItem{ Value = "Dr", Text = "Dr"}
        };

        //For testing, I just hard code here
        List<People> people = new List<People>()
        {
            new People()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Title = "Mr",
            },
            new People()
            {
                FirstName = "Sam",
                LastName = "Perry",
                Title = "Mrs"
            },
            new People()
            {
                FirstName = "Jack",
                LastName = "Jones",
                Title = "Dr"
            }
        };

        public IActionResult Index()
        {
            ViewBag.select = selectListItems;
            return View(people);
        }

        [HttpPost]
        public IActionResult Index(List<People> model)
        {
            return RedirectToAction("Index");
        }
    }
}
