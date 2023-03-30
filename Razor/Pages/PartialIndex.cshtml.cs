using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Models;

namespace Razor.Pages
{
    public class PartialIndexModel : PageModel
    {
        [BindProperty]
        public StatusReport StatusReport { get; set; } = new StatusReport()
        {
            Name = "TestAAA",
            PartialName = "PartialAAA"
        };

        [BindProperty]
        public string status { get; set; } = "Do";


        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAjax(string value)
        {
            switch (value)
            {
                case "Do":
                    status = "Do";
                    break;
                case "Done":
                    status = "Done";
                    break;
                case "Canceled":
                    status = "Canceled";
                    break;
            }
            return new JsonResult(status);
        }
    }
}
