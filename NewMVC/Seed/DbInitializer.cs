using NewMVC.Data;
using NewMVC.Models;

namespace NewMVC.Seed
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            List<SeedModel> seedDatas = new List<SeedModel>();
            seedDatas.Add(new SeedModel()
            {
                Name = "AAAA",
                Age = 2
            });
            seedDatas.Add(new SeedModel()
            {
                Name = "BBB",
                Age = 3
            });
            seedDatas.Add(new SeedModel()
            {
                Name = "AAAA",
                Age = 2
            });
            //string a = Console.ReadLine();

            await context.SeedModels.AddRangeAsync(seedDatas);
            await context.SaveChangesAsync();

        }
    }
}
