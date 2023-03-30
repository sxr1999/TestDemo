using Microsoft.EntityFrameworkCore;
using Razor.Models;

namespace Razor.ApplicationDbContext
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options):base(options)
        {
            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<LibraryItem> LibraryItem { get; set; }
    }
}
