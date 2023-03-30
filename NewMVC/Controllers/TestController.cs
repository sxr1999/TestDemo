using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewMVC.Data;
using NewMVC.Models;

namespace NewMVC.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            await DbInitializer.InitializeAsync(_context);
            return View();
        }

        [HttpPost]
        public IActionResult Index(MVC1 model)
        {
            if (ModelState.IsValid)
            {
                string fileContent = "sdfafaf";
                return RedirectToAction("myaction", "Test", new { fileContent = fileContent });
            }

            return View();
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create123()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult myaction(string fileContent)
        {
            return View();
        }

        public IActionResult Create()
        {

            ViewBag.data = _context.Classes.ToList();
            return View();
        }


        public IActionResult CreateDegreeName()
        {
            var data = _context.dropDownDatas.Select(x=>x.IdDegree).Distinct().ToList();
            var selectlist = new List<SelectListItem>();
            var selectlistTitle = new List<SelectListItem>();
            foreach (var item in data)
            {
                selectlist.Add(new SelectListItem() { Text = item, Value = item });
            }

            ViewBag.selectlist = selectlist;

           
            return View();
        }

        [HttpPost]
        public IActionResult CreateDegreeName(DegreeName model)
        {
            //..........
            return RedirectToAction("CreateDegreeName");
        }

        public IActionResult addItem(string IdDegree)
        {
            var title = _context.dropDownDatas.Where(y => y.IdDegree == IdDegree).Select(x => x.DegreeTitle).ToList();
            return Json(title);
        }

        public IActionResult Privacy()
        {
            List<SelectListItem> selectlist = new List<SelectListItem>();
            selectlist.Add(new SelectListItem() { Text = "1",Value = "1"});
            selectlist.Add(new SelectListItem() { Text = "2", Value = "2" });
            selectlist.Add(new SelectListItem() { Text = "3", Value = "3" });
            selectlist.Add(new SelectListItem() { Text = "4", Value = "4" });
            selectlist.Add(new SelectListItem() { Text = "5", Value = "5" });
            ViewBag.data = selectlist;
            return View();
        }

        [HttpPost]
        public IActionResult Privacy(FruitViewModel model)
        {
            return RedirectToAction("Privacy");
        }

            

        [HttpPost]
        public IActionResult Create(Subject subject)
        {

            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Hello()
        {
            FirstLevel first = new FirstLevel();
            List<SecondLevel> seconds = new List<SecondLevel>();
           seconds.Add(new SecondLevel()
           {
               EnumTypeSample = AnEnumType.secondone
           });
            seconds.Add(new SecondLevel()
            {
                EnumTypeSample = AnEnumType.firstone
            });
            seconds.Add(new SecondLevel()
            {
                EnumTypeSample = AnEnumType.firstone
            });
            first.SecondLevelEntities = seconds;


            return View(first);
        }



        public IActionResult Validate()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Validate(Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return View("Validate");
            };

            return View();
        }


        public IActionResult Test()
        {
            var test = new List<SelectListItem>();
           
            

            test.Add(new SelectListItem()
            {
                Text = "male",
                Value = "0"
            });
            test.Add(new SelectListItem()
            {
                Text = "female",
                Value = "1"
            });

            ViewBag.gender = test;

            TestA testA = new TestA();
            testA.Test = new List<string>()
            {
                "sss",
                "vvv",
                "ddd",
                "xxxxx"
            };

            testA.testb.Add(new TestB()
            {
                A = "vvv",
                B = "ss"
            });

            return View(testA);
        }

        [HttpPost]
        public IActionResult Test(TestModel model)
        {
            return RedirectToAction("create");
        }

        //List<City> cities = new List<City>()
        //{
        //    new City()
        //    {
        //        Id = 1,
        //        Name = "AAA"
        //    },
        //    new City()
        //    {
        //        Id = 3,
        //        Name = "BBB"
        //    },
        //    new City()
        //    {
        //        Id = 4,
        //        Name = "CCC"
        //    },
        //    new City()
        //    {
        //        Id = 5,
        //        Name = "DDD"
        //    },
        //};

        //List<LocationA> locations = new List<LocationA>()
        //{
        //    new LocationA()
        //    {
        //        Id = 1,
        //        ItemId = 1,
        //        Name = "a",
        //        Latitude = "a",
        //        Longitude = "a",
        //    },
        //    new LocationA()
        //    {
        //        Id = 2,
        //        ItemId = 3,
        //        Name = "b",
        //        Latitude = "b",
        //        Longitude = "b",
        //    },
        //    new LocationA()
        //    {
        //        Id = 3,
        //        ItemId = 4,
        //        Name = "c",
        //        Latitude = "c",
        //        Longitude = "c",
        //    },
        //    new LocationA()
        //    {
        //        Id = 4,
        //        ItemId = 5,
        //        Name = "d",
        //        Latitude = "d",
        //        Longitude = "d",
        //    }           
        //};

        //public List<City> add()
        //{
        //    cities.ForEach(c =>
        //    {
        //        c.Location = locations.Where(x => x.ItemId == c.Id).Select(x => new LocationA(){Id= x.Id,Name= x.Name,Latitude=x.Latitude,Longitude=x.Longitude}).FirstOrDefault();
        //    });

        //    return cities;
        //}

        Country country = new Country()
        {
            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            Name = "US",
            States = new List<State>()
            {
                new State()
                {
                    Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Name = "California",
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66aab4"),
                            Name = "LA"
                        }
                    }
                },
                new State(){
                    Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    Name = "Maine",
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66aab5"),
                            Name = "LA"
                        },
                        new City()
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66aab6"),
                            Name = "NY"
                        }
                    }
                }
            }

        };

        List<LocationA> locationAs = new List<LocationA>() {
            new LocationA(){
                Id = Guid.NewGuid(),
                ItemId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66aab4"),
                Name = "Location X",
                Latitude = "aaaa",
                Longitude = "bbbb"
            },
            new LocationA(){
                Id = Guid.NewGuid(),
                ItemId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66aab5"),
                Name = "Location y",
                Latitude = "ccccc",
                Longitude = "ddddd"
            }
        };

        public Country get()
        {
            country.States.ForEach(x =>
            {
                x.Cities.ForEach(y =>
                {
                    y.Location = locationAs.Where(z => z.ItemId == y.Id).Select(d=> new {Id=d.Id,Name = d.Name, Latitude = d.Latitude, Longitude = d.Longitude }).FirstOrDefault();
                });
            });

            return country;
        }



    }
}
