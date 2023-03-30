using NewMVC.Models;
using Newtonsoft.Json;

namespace NewMVC
{
    public class Crawler
    {
        public static async Task<Show> CrawlShowAsync(long ShowId)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.tvmaze.com/shows/" + ShowId;
            string response = await client.GetStringAsync(url);
            var Show = JsonConvert.DeserializeObject<Show>(response);
            return Show;
        }
        public static async Task<List<CastTemp>> GetCastsAsync(long ShowId)
        {
            List<CastTemp> Casts = new List<CastTemp>();
            HttpClient client = new HttpClient();
            string urlcast = "https://api.tvmaze.com/shows/" + ShowId + "/cast";
            string responseCast = await client.GetStringAsync(urlcast);
            List<Person> result = JsonConvert.DeserializeObject<List<Person>>(responseCast);
            foreach (var item in result)
            {
                Casts.Add(item.castTemp);
            }
            return Casts;
        }
    }
}
