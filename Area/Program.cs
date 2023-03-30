using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Area.Data;
namespace Area
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("AreaContextConnection") ?? throw new InvalidOperationException("Connection string 'AreaContextConnection' not found.");

                                    builder.Services.AddDbContext<AreaContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AreaContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{area=Test}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "MyArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}