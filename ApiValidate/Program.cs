using ApiValidate.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace ApiValidate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                //c.SchemaFilter<SwaggerExcludeClrTypesFilter>();
                c.MapType<DateTime>(() => new OpenApiSchema { Type = "Date", Format = "date-time" });
            });

            var connectionString = builder.Configuration.GetConnectionString("default");
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}