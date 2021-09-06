using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearch.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelSearch.Infrastructure.Persistence
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly HotelsDbContext _context;

        public HotelsRepository(HotelsDbContext context)
        {
            _context = context;
        }

        #region Implementation of IHotelsRepository

        public async Task<IEnumerable<Hotel>> GetHotelsList()
        {
            if (!_context.Hotels.Any())
            {
                await HotelsDbContextSeed.SeedAsync(_context);
            }

            return await _context.Hotels.ToListAsync();
        }

        #endregion
    }
}
