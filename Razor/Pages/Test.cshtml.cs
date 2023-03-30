using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages
{
    public class TestModel : PageModel
    {
        

        public string Message = "";
        public void OnGet()
        {
            Message = "Hello";
        }
    }
}
