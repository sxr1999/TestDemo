using Microsoft.AspNetCore.Mvc;

namespace API11.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         };

        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("upload")]
       
        public async Task<IActionResult> Upload()
        {
            // Console.WriteLine(HttpContext.Request.Form);
            //var result = httpContextAccessor.HttpContext.Request.Form;

            var result = HttpContext.Request.Body;

            return StatusCode(202, new { test = "bruh" });
        }

        [HttpPost("Test")]
        public IActionResult Test([FromForm]string name)
        {
            return Ok(name);
        }
    }
}