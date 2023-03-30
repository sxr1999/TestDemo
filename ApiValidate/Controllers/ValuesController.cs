using ApiValidate.ApplicationDbContext;
using ApiValidate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiValidate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController<MyDateTime>
    {
        public ValuesController(MyDbContext context) : base(context)
        {
        }
    }
}
