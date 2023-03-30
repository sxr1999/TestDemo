using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.Design;

namespace Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        [BindProperty(SupportsGet = true)]
        public List<string>? colors { get; set; }


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }





        public void OnGet()
        {
           
        }

        [HttpPost]
        public IActionResult OnPost(string Message =null)
        {
            if (ModelState.Remove("Message"))
            {
                return Page();
            }
            else
            {
                return RedirectToPage("privacy");
            }
        }
    }
}