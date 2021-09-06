using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelSearch.Infrastructure.Domain;
using HotelSearch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace HotelSearch.Infrastructure.Tests
{
    [TestClass]
    public class HotelSearchRepositoryTests
    {
        private readonly HotelsDbContext _hotelsDbContext;
        private readonly IHotelsRepository _hotelsRepository;

        public HotelSearchRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HotelsDbContext>()
                .UseInMemoryDatabase(databaseName: "HotelsDb")
                .Options;
            _hotelsDbContext = new HotelsDbContext(dbOptions);
            _hotelsRepository = new HotelsRepository(_hotelsDbContext);
        }

        [TestMethod]
        public async Task GetAllHotelsFromJSON()
        {
            List<Hotel> hotelList = (List<Hotel>)await _hotelsRepository.GetHotelsList();
            Assert.IsTrue(hotelList.Count == 11);
        }

        [TestMethod]
        public async Task JSONFileNotFound()
        {
            HotelsDbContextSeed.FileName = "Nofile.json";
            List<Hotel> hotelList = (List<Hotel>)await _hotelsRepository.GetHotelsList();
            Assert.IsTrue(hotelList.Count == 0);
        }
    }
}
