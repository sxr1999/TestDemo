namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.UsePathBase("/myapp");

            // Create a "side branch" that always prints the path info when run
            app.Map("/app1", app1 => app1
                .Run(ctx => ctx.Response.WriteAsync(
                    $"App1: PathBase: {ctx.Request.PathBase} Path: {ctx.Request.Path}")));

            // If the side branch isn't run, print the path info
            app.Run(ctx => ctx.Response.WriteAsync(
                $"App1: PathBase: {ctx.Request.PathBase} Path: {ctx.Request.Path}"));

            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}