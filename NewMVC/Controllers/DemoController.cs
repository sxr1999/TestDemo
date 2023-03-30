using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewMVC.Data;
using NewMVC.Models;
using NewMVC.Models2;
using System.Net.Mime;
using System.Reflection;

namespace NewMVC.Controllers
{
    public class DemoController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public DemoController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            Assembly assem = typeof(DemoController).Assembly;
            Console.WriteLine(assem.FullName);


            InvRows invRows = new InvRows()
            {
                PL = new List<Select>()
                {
                    new Select()
                    {
                        ProdId = 1,
                        Price = "32",
                        Prodname = "AAA"
                    },
                    new Select()
                    {
                        ProdId = 2,
                        Price = "44",
                        Prodname = "BBB"
                    },
                    new Select()
                    {
                        ProdId = 3,
                        Price = "52",
                        Prodname = "CCC"
                    },
                    new Select()
                    {
                        ProdId = 4,
                        Price = "16",
                        Prodname = "DDD"
                    },
                    new Select()
                    {
                        ProdId = 5,
                        Price = "77",
                        Prodname = "EEE"
                    }
                }
            };
            return View(invRows);
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetItem1(string selectedIndex)
        {
            var currentTemplate = templates.SingleOrDefault(x => x.Item2 == selectedIndex).Item1;
            return Json(currentTemplate);
        }


        [HttpPost]
        public IActionResult Index(InvRows model)
        {
            return View();
        }

        public IActionResult Test()        
        {
            var itemSectionGroup = _dbcontext.item.Where(x => !string.IsNullOrEmpty(x.SECTION_GROUP));
            //var itemSectionGroupNull = _dbcontext.item.Where(x => string.IsNullOrEmpty(x.SECTION_GROUP)).FirstOrDefault();
           
            var resultList = new List<Item>();          

            var result =  itemSectionGroup.GroupBy(x => x.SECTION_GROUP).Select(x => x.Key).ToList();

            for (int i = 0; i < result.Count(); i++)
            {
                var session1 = itemSectionGroup.Where(x => x.SECTION_GROUP == result[i]).ToList();
                var Nullsession = _dbcontext.item.Where(x => string.IsNullOrEmpty(x.SECTION_GROUP)).AsNoTracking().FirstOrDefault();
                session1.Add(Nullsession);
                session1.ForEach(x => x.GROUP_ID = (i + 1));
                resultList.AddRange(session1);
                
            };
            return View();
        }

        //public IActionResult SendFile()
        //{
        //    var filePath = @"C:\Users\Administrator\Downloads\LIBRARY.zip";
        //    var fileName = "LIBRARY";

        //    var stream = new FileStream(filePath, FileMode.Open);

        //    return new FileStreamResult(stream, "application/octet-stream")
        //    {
        //        FileDownloadName = fileName
        //    };
        //}

        [HttpPost]
        public IActionResult Upload(Photo model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "POST file successful!";

            }
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Privacy(TestOne model)
        {
            return View();
        }


        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Cat()
        {
            return View();
        }

        public IActionResult Let()
        {
            return View();
        }


        List<ClonePost> clonePosts = new List<ClonePost>()
        {
            new ClonePost()
            {
                id = 1,
                PostNumber = "111",
                Type = "A",
                ItemNumber = 1,
                ItemData = "AAA",
                ItemSelected = 1
            },
             new ClonePost()
            {
                id = 2,
                PostNumber = "111",
                Type = "B",
                ItemNumber = 2,
                ItemData = "BBB",
                ItemSelected = 2
            },
              new ClonePost()
            {
                id = 3,
                PostNumber = "111",
                Type = "C",
                ItemNumber = 3,
                ItemData = "CCC",
                ItemSelected = 3
            },
               new ClonePost()
            {
                id = 4,
                PostNumber = "222",
                Type = "D",
                ItemNumber = 4,
                ItemData = "DDD",
                ItemSelected = 4
            }
        };

        public async Task<IActionResult> ReviewClone(string zero = "230323-0")
        {
            
        //now call up the full table for review and edit
            var cloned =  clonePosts.OrderByDescending(m => m.PostNumber).ToList();
            ReviewCloneVM vm = new ReviewCloneVM()
            {
                ClonePosts = cloned,
            };
            return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> ReviewClone(ReviewCloneVM reviewCloneVM)
        {
            try
            {
                // other stuff
                return RedirectToAction("PostDetail", "Post", new { zero = "230323-0" });
            }
            catch
            {
                return View(reviewCloneVM);
            }
        }
    }
}
