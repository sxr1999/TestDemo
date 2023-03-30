using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor.ApplicationDbContext;
using Razor.Models;

namespace Razor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LibraryManagementContext _context;

        public CreateModel(LibraryManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            List<Category> categories = _context.Category.ToList();
            ViewData["Categories"] = new SelectList(categories, "ID", "CategoryName");
            //LibraryItems = await _context.LibraryItem.Include(x => x.Category).ToListAsync();
            return Page();
        }

        [BindProperty]
        public LibraryItem LibraryItem { get; set; } = default!;
        public Category LibraryCategory { get; set; }
        public SelectList getCategories { get; set; }

        public IList<LibraryItem> LibraryItems { get; set; } = default!;


        public SelectList getTypes { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.LibraryItem == null || LibraryItem == null)
            {
                return Page();
            }
            _context.LibraryItem.Add(LibraryItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
