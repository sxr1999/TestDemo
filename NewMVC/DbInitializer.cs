using NewMVC.Data;
using NewMVC.Models;

namespace NewMVC
{
    public static class DbInitializer
    {
        static List<List<Cast>> listedCasts = new List<List<Cast>>();
        static List<Show> listedShows = new List<Show>();
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            for (long i = 1; i < 10; i++)
            {
                long ShowId = i;
                Show show = await Crawler.CrawlShowAsync(ShowId);
                listedShows.Add(show);
                List<CastTemp> tempCasts = await Crawler.GetCastsAsync(ShowId);
                List<Cast> casts = CastTemp.TempCastToCast(tempCasts, ShowId);
                listedCasts.Add(casts);
            }
            context.Database.EnsureCreated();

            if (context.shows.Any())
            {
                return;   // DB has been seeded
            }


            foreach (Show s in listedShows)
            {
                await context.shows.AddAsync(s);

            }
            //await context.SaveChangesAsync();

            List<long> a = new List<long>();

            foreach (List<Cast> castsList in listedCasts)
            {
                foreach (Cast cast in castsList.DistinctBy(x=>x.CastId))
                {
                    //context.ChangeTracker.Clear();
                    await context.casts.AddAsync(cast);
                    a.Add(cast.CastId);

                }
            }



            var duplicates = a.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            var result = listedCasts.SelectMany(x => x).Where(y => y.CastId == 91).ToList();

            await context.SaveChangesAsync();

        }
    }


}
