using ApiValidate.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiValidate.ApplicationDbContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        public DbSet<MyDateTime>  datetimes { get; set; }
        public DbSet<TestModel> testModels { get; set; }
    }
}
