using ApiValidate.ApplicationDbContext;
using ApiValidate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApiValidate.Controllers
{
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseModel
    {
        public DbSet<T> _dbSet { get; set; }
        private readonly MyDbContext _context;

        public BaseController(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
       

        [HttpGet]
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = typeof(T);

            if (result.Name.Equals("MyDateTime"))
            {
                return await _dbSet.Skip(1).Take(4).ToListAsync();
            }


            return await _dbSet.ToListAsync();
        }
    }
}
