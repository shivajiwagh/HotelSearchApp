using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using HotelSearch.Infrastructure.Domain;
using Newtonsoft.Json;

namespace HotelSearch.Infrastructure.Persistence
{
    public class HotelsDbContextSeed
    {
        public static string FileName { get; set; } = "Hotels.json";
        public static async Task SeedAsync(HotelsDbContext context)
        {
            try
            {
                string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string fileFullName = Path.Combine(assemblyFolder ?? string.Empty, FileName);
                string hotelList = await File.ReadAllTextAsync(fileFullName);
                List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(hotelList);
                await context.Hotels.AddRangeAsync(hotels ?? new List<Hotel>());
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
