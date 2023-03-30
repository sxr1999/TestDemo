
using AspNetCoreRateLimit;
using System.Threading.RateLimiting;

namespace Api7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddOutputCache();

            //builder.Services.AddMemoryCache();
            //builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            //builder.Services.AddInMemoryRateLimiting();

            //builder.Services.Configure<IpRateLimitOptions>(options =>
            //{
            //    options.EnableEndpointRateLimiting = true;
            //    options.StackBlockedRequests = false;
            //    options.HttpStatusCode = 429;
            //    options.RealIpHeader = "X-Real-IP";
            //    options.GeneralRules = new List<RateLimitRule>
            //    {
            //        new RateLimitRule
            //        {
            //            Endpoint = "*",
            //            Period = "10s",
            //            Limit = 2
            //        }
            //    };
            //});

            //builder.Services.AddRateLimiter(options =>
            //{
            //    //options.EndpointLimiterFactory = (context, endpointKey) =>
            //    //    PartitionedRateLimiter.Create<string, string>(key =>
            //    //        RateLimitPartition.GetFixedWindowLimiter(
            //    //            partitionKey: key,
            //    //            factory: partition => new FixedWindowRateLimiterOptions
            //    //            {
            //    //                AutoReplenishment = true,
            //    //                PermitLimit = 5,
            //    //                QueueLimit = 0,
            //    //                Window = TimeSpan.FromSeconds(20)
            //    //            })
            //    //        )(endpointKey);
                
            //    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            //});


            //builder.Services.AddRateLimiter(options =>
            //{
            //    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(content =>
            //        RateLimitPartition.GetFixedWindowLimiter(
            //            partitionKey: content.Request.Headers.Host.ToString(),
            //            factory: partition => new FixedWindowRateLimiterOptions
            //            {
            //                AutoReplenishment = true,
            //                PermitLimit = 5,
            //                QueueLimit = 0,
            //                Window = TimeSpan.FromSeconds(20)
            //            }

            //            ));
            //    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            //});

            //builder.Services.AddRateLimiter(options =>
            //{
            //    options.AddPolicy("Api", httpContext =>
            //        RateLimitPartition.GetFixedWindowLimiter(
            //        partitionKey: httpContext.Request.Headers.Host.ToString(),
            //        factory: partition => new FixedWindowRateLimiterOptions
            //        {
            //            AutoReplenishment = true,
            //            PermitLimit = 4,
            //            QueueLimit = 0,
            //            Window = TimeSpan.FromSeconds(10)
            //        }));
            //    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            //});

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseOutputCache();


            app.MapControllers();

            //app.UseRateLimiter();

            app.Run();
        }
    }
}