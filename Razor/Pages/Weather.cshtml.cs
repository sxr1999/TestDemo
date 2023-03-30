using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public WeatherModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public void OnGet()
        {
        }

        public IActionResult OnGetAjax(string weather)
        {
            var htmlFilePath = "";
            string fileToSend = "";
            switch (weather)
            {
                case "Sunny":
                    htmlFilePath = Path.Combine(webHostEnvironment.WebRootPath, "SVG", "Sunny.svg");
                    fileToSend = Convert.ToBase64String(System.IO.File.ReadAllBytes(htmlFilePath));
                    return Content(fileToSend);
                    
                case "Windy":
                    htmlFilePath = Path.Combine(webHostEnvironment.WebRootPath, "SVG", "Windy.svg");
                    fileToSend = Convert.ToBase64String(System.IO.File.ReadAllBytes(htmlFilePath));
                    return Content(fileToSend);

                case "Cloudy":
                    htmlFilePath = Path.Combine(webHostEnvironment.WebRootPath, "SVG", "Cloudy.svg");
                    fileToSend = Convert.ToBase64String(System.IO.File.ReadAllBytes(htmlFilePath));
                    return Content(fileToSend);


                //..........
                
            }

            return Content("");
            

        }
    }
}
