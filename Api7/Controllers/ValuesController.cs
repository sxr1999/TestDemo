using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            Console.WriteLine(HttpContext.Request.Form);

            return StatusCode(202, new { test = "bruh" });
        }
    }
}
