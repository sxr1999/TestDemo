using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewMVC.Data;
using NewMVC.Models;
using System.Diagnostics;
using System.Security.Claims;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using ObjectsComparer;
using System.Collections;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;
using NewMVC.Filters;

namespace NewMVC.Controllers
{
    [ShowMessage("controller123")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        private readonly IHttpContextAccessor _Accessor;
        public List<UserModel> users = null;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbcontext, IHttpContextAccessor accessor, IMapper mapper)
        {
            
            _logger = logger;
            _dbcontext = dbcontext;
            users = new List<UserModel>();
            users.Add(new UserModel()
            {
                UserId = 1,
                Username = "Anoop",
                Password = "123",
                Role = "Admin"
            });
            users.Add(new UserModel()
            {
                UserId = 2,
                Username = "Other",
                Password = "123",
                Role = "User"
            });
            _Accessor = accessor;
            _mapper = mapper;
        }

        [ShowMessage("action123")]
        public IActionResult Index()
        {
            var rooms = _dbcontext.rooms.ToList();
            var floors = _dbcontext.floors.ToList();

            List<SelectListItem> list1 = new List<SelectListItem>();
            List<SelectListItem> list2 = new List<SelectListItem>();
            foreach (var ro in rooms)
            {
                var listItem = new SelectListItem();
                listItem.Text = ro.Name;
                listItem.Value = ro.Id.ToString();
                list1.Add(listItem);
            }
            foreach (var item in floors)
            {
                var listItem = new SelectListItem();
                listItem.Text = item.Name;
                listItem.Value = item.Id.ToString();
                list2.Add(listItem);
            }
            ViewBag.rooms = list1;
            ViewBag.floors = list2;
            return View();
        }

        [HttpPost]
        public IActionResult Watchlist(string stockTicker, string userId)
        {
            return RedirectToAction("privacy");
        }

        public async Task<IActionResult> Upload()
        {

               var result =  _dbcontext.casts.Where(x => x.CastId == 3).FirstOrDefault();
                result.Name = "ssssss";
                _dbcontext.SaveChanges();
            //var result = await from x in _dbcontext.casts
            //                   where x.ShowId == 3
            //                   orderby x.Birthday
            //                   select new Cast
            //                   {
            //                       CastId = x.CastId,
            //                       Birthday = x.Birthday
            //                   }.

            //var myposts = (from x in _context.myPosts
            //               where x.IsApproved == "FAQ"
            //               orderby x.PublishDate
            //               select new myPosts
            //               {
            //                   Id = x.Id,
            //                   Title = x.Title,
            //                   Summary = x.Summary,
            //                   Content = x.Content.Substring(0, 200),
            //                   /*more fields*/
            //               }).ToList();


            

            //var result = await _context.myPosts.Where(x => x.IsApproved == "FAQ").OrderBy(x => x.PublishDate).Select(x => new myPosts { Id = x.Id, Title = x.Title, Summary =x.Summary, Content = x.Content.Substring(0, 200) }).ToListAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Upload(FileViewModel model)
        {
            foreach (var file in model.FormFile)
            {
                if (file.Length > 0)
                {
                    using (var memorySteam = new MemoryStream())
                    {
                        await file.CopyToAsync(memorySteam);

                        var File = new AppFile()
                        {
                            FileName = file.FileName,
                            Content = memorySteam.ToArray()
                        };
                        _dbcontext.File.Add(File);
                        await _dbcontext.SaveChangesAsync();

                    }
                }

            }
            return View();
        }

        public async Task www()
        {
            await Uploadfilefromdb(1);
        }


        public async Task Uploadfilefromdb(int id)
        {
            var result =await _dbcontext.File.FirstOrDefaultAsync(x => x.Id == id);
            var fileName = Path.GetFileName(result.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images",fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                //convert byte[] to IformFile
                var stream = new MemoryStream(result.Content);
                IFormFile file = new FormFile(stream, 0, result.Content.Length, "name", fileName);

                await file.CopyToAsync(fileStream);
            }
        }

        [HttpPost]
        public IActionResult Index(ViewTestModel model)
        {
            Location location = new Location();
            var room = _dbcontext.rooms.Where(x=>x.Id==model.location.RoomId).FirstOrDefault();
            var floor = _dbcontext.floors.Where(x => x.Id == model.location.FloorId).FirstOrDefault();
            location.Room = room;
            location.Floor = floor;
            location.Row = model.location.Row;

            Equipment equipment = new Equipment();
            equipment.Name = model.equipment.Name;
            equipment.Amount = model.equipment.Amount;
            equipment.Location = location;
            _dbcontext.equipments.Add(equipment);
            _dbcontext.SaveChanges();

            //.....other code..............

            return RedirectToAction("index");
        }

        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Test()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "AAA",Value = "1"});
            list.Add(new SelectListItem() { Text = "BBB", Value = "2" });
            list.Add(new SelectListItem() { Text = "CCC", Value = "3" });
            list.Add(new SelectListItem() { Text = "DDD", Value = "4" });
            list.Add(new SelectListItem() { Text = "EEE", Value = "5" });
            list.Add(new SelectListItem() { Text = "FFF", Value = "6" });
            list.Add(new SelectListItem() { Text = "GGG", Value = "7" });
            list.Add(new SelectListItem() { Text = "HHH", Value = "8" });
            ViewBag.Employees = list;
            return View();
        }

        [HttpPost]
        public IActionResult Test(Employee model)
        {
            return RedirectToAction("Test");
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = users.Where(x => x.Username == objLoginModel.UserName && x.Password == objLoginModel.Password).FirstOrDefault();
                if (user == null)
                {
                    //Add logic here to display some message to user    
                    ViewBag.Message = "Invalid Credential";
                    return View(objLoginModel);
                }
                else
                {
                    //A claim is a statement about a subject by an issuer and    
                    //represent attributes of the subject that are useful in the context of authentication and authorization operations.    
                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim("FavoriteDrink", "Tea")
                };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = objLoginModel.RememberLogin
                    });
                    return RedirectToAction("index");
                }
            }
            return View(objLoginModel);
        }

        public IActionResult FandC()
        {
            var jwt = ParseTokenClaims("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKaWduZXNoIFRyaXZlZGkiLCJlbWFpbCI6InRlc3QuYnRlc3RAZ21haWwuY29tIiwiRGF0ZU9mSm9pbmciOiIwMDAxLTAxLTAxIiwianRpIjoiYzJkNTZjNzQtZTc3Yy00ZmUxLTgyYzAtMzlhYjhmNzFmYzUzIiwiZXhwIjoxNTMyMzU2NjY5LCJpc3MiOiJUZXN0LmNvbSIsImF1ZCI6IlRlc3QuY29tIn0.8hwQ3H9V8mdNYrFZSjbCpWSyR1CNyDYHcGf6GqqCGnY");

            

          
            return View();
        }

        private Dictionary<object,object> ParseTokenClaims(string access_token)
        {

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(access_token);

            var claims = jwt.Claims.ToList();

            Dictionary<object, object> result = new Dictionary<object, object>();
            foreach (var claim in claims)
            {
                result.Add(claim.ToString().Trim().Split(":")[0], claim.ToString().Trim().Split(":")[1]);
            }

            return result;
        }


        public IActionResult Compare()
        {

            //current model
            var a1 = new ClassA()
            {
                Id = 1,
                FirstName = "AAA",
                Age = 23,
                LastName = "BB",
                subClassA = new List<SubClassA>()
                {
                    new SubClassA()
                    {
                        Name = "AAA"
                    },
                    new SubClassA()
                    {
                        Name = "BBB"
                    },
                    new SubClassA()
                    {
                        Name = "CCC"
                    }
                }
            };

            //new model from frontend
            var a2 = new ClassA()
            {
                Id = 1,
                FirstName = "AAA",
                Age = 16,
                LastName = "BBVV",
                subClassA = new List<SubClassA>()
                {
                    new SubClassA()
                    {
                        Name = "AAA"
                    },
                    new SubClassA()
                    {
                        Name = "BEB"
                    },
                    new SubClassA()
                    {
                        Name = "CCC"
                    }
                }
            };

            //receive the different properties
            List<ComparedModel> t = new List<ComparedModel>();

            var comparer = new ObjectsComparer.Comparer<ClassA>();
            IEnumerable<Difference> differences;
            var isEqual = comparer.Compare(a1, a2, out differences);
            

            if (!isEqual)
            {
                foreach (var item in differences)
                {
                    t.Add(new ComparedModel()
                    {
                        Description = item.MemberPath,
                        OldValue = item.Value1,
                        NewValue = item.Value2
                    });
                   
                }
            }

            return RedirectToAction("index");
        }

        public IActionResult ErrorTest()
        {
            throw new Exception("Custom error message");
            return View();
        }


        public IActionResult Show()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var result = _dbcontext.students.ToList();
            foreach (var item in result)
            {
                list.Add(new SelectListItem() { Value = item.Id.ToString(),Text = item.StudentName});
            }
            ViewBag.student = list;
            return View();
        }

        [HttpPost]
        public JsonResult Show(int id)
        {
            var query = _dbcontext.students.Where(p => p.Id == id).FirstOrDefault();
                       

            return Json(query);
        }


        public IActionResult Create()
        {
            var newquiz = new Quiz();
            return View(newquiz);
        }



        //[Authorize]
        public IActionResult Privacy()
        {
            var name = _Accessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            Date date = new Date();
            date.Year = 6; 
            var FavoriteDrink = _Accessor.HttpContext.User.FindFirstValue("FavoriteDrink");
            return View(date);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UploadFileUsingJQueryAJAX()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFileUsingJQueryAJAX(Employees emp)
        {
            return View();
        }

        List<User> localUsers = new List<User>()
        {
            new User()
            {
                Id = new Guid("C6DB3F7D-0FE3-3256-1BCC-D64CA4A439B5"),
                Name = "A",
                Mail = "AAA",
                PwLastSet = DateTime.Now
            },
            new User()
            {
                Id = new Guid("F1E48FC2-8CDE-4461-88C7-AC7C6F3A5DEE"),
                Name = "B",
                Mail = "BBB",
                PwLastSet = DateTime.Now
            },
            new User()
            {
                Id = new Guid("A4531114-AF18-2775-0AB1-585433E30FDE"),
                Name = "C",
                Mail = "CCC",
                PwLastSet = DateTime.Now
            }
        };

        List<User> remoteUsers = new List<User>()
        {
            new User()
            {
                Id = new Guid("C6DB3F7D-0FE3-3256-1BCC-D64CA4A439B5"),
                Name = "A",
                Mail = "AAA",
                PwLastSet = DateTime.Now
            },
            new User()
            {
                Id = new Guid("F1E48FC2-8CDE-4461-88C7-AC7C6F3A5DEE"),
                Name = "B",
                Mail = "ABABA",
                PwLastSet = DateTime.Now
            },
            new User()
            {
                Id = new Guid("A4531114-AF18-2775-0AB1-585433E30FDE"),
                Name = "C",
                Mail = "CCC",
                PwLastSet = DateTime.Now
            },
            new User()
            {
                Id = new Guid("4B6065FD-974B-3D45-EFC3-568FFC696B88"),
                Name = "D",
                Mail = "DDD",
                PwLastSet = DateTime.Now
            }
        };

        public async Task<IActionResult> mapper()
        {
            var toAdd = new List<User>();
            foreach (var remoteUser in remoteUsers)
            {
                var localUser = localUsers.FirstOrDefault(x => x.Id.Equals(remoteUser.Id));
                if (localUser == null)
                {
                    toAdd.Add(remoteUser);
                }
                else if (!localUser.Equals(remoteUser))
                {
                    _mapper.Map(remoteUser, localUser);
                    var result = localUser;
                }
            }

            await _dbcontext.Set<User>().AddRangeAsync(toAdd);
            await _dbcontext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public IActionResult PassMultipleCustomersFromViewToController()
        {
            var customers = new List<Customer>();
            return View(customers);
        }

        [HttpPost]
        public JsonResult InsertCustomers([FromBody] Customer[] customers)
        {
            return Json(customers);
        }

        public IActionResult ShowTest()
        {
            var model = _dbcontext.prefessor.ToList();
            return View(model);
        }

        public IActionResult Json()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JsonAsync(string json)
        {
            //await _dbcontext.Database.ExecuteSqlCommandAsync("");
            return View();
        }

        public async Task<IActionResult> Get()
        {
            var DisplayAgencyData = await _dbcontext.Agency.ToListAsync();
            ViewBag.data =  new SelectList(DisplayAgencyData.OrderBy(x => x.AgencyName), "Id", "AgencyName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Get(Officer officer)
        {
            if (ModelState.IsValid)
            {
                await _dbcontext.Officers.AddAsync(officer);
                return RedirectToAction("Get");
            }

            return RedirectToAction("Get");
        }

    }
}