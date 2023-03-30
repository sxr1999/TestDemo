using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Razor.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }


        [BindProperty]
        public List<string>? colors { get; set; }


        public List<SelectListItem>? Colors_SELECT { get; set; }

        public void OnGet()
        {
            colors = new List<string>();
            colors.Add("red");
            colors.Add("green");
            colors.Add("black");

            Colors_SELECT = new List<SelectListItem>();

            new SelectListItem { Text = "red", Value = "red" };
            new SelectListItem { Text = "black", Value = "black" };
            new SelectListItem { Text = "white", Value = "white" };
            new SelectListItem { Text = "green", Value = "green" };
           


        }

        public IActionResult OnPost()
        {
            //other code

            //redirect to index.cshtml
           return RedirectToPage("index");
        }
    }
}