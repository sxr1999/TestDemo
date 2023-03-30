using DependentLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NewMVC.Data;
using NewMVC.Filters;
using NewMVC.Models;
using NewMVC.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var assembly = typeof(NoGoodController).Assembly;
var part = new AssemblyPart(assembly);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews().ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(part));
builder.Services.Configure<Country>(builder.Configuration.GetSection("country"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Home/Login";
    });
builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UsePathBase("/test");

//var options = new RewriteOptions()
//    .AddRewrite(@"^admin/abc/(.*)", @"test/$1", true)
//    ;

//app.UseRewriter(options);


app.UseHttpsRedirection();
app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Views")),
        RequestPath = "/Views"
    }
);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    //Resolve ASP .NET Core Identity with DI help
    var dbcontext = (ApplicationDbContext)scope.ServiceProvider.GetService(typeof(ApplicationDbContext));

    // do you things here

    await DbInitializer.InitializeAsync(dbcontext);
}

//app.MapControllerRoute(
//    name: "MyArea",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
