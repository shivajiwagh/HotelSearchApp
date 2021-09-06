using System.Collections.Generic;
using System.Threading.Tasks;
using HotelSearch.Infrastructure.Domain;

namespace HotelSearch.Infrastructure.Persistence
{
    public interface IHotelsRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsList();
    }
}
