using HotelSearch.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelSearch.Infrastructure.Domain;

namespace HotelSearch.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelSearchController
    {
        private readonly IHotelsRepository _repository;

        public HotelSearchController(IHotelsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetAsync()
        {
           return await _repository.GetHotelsList();
        }
    }
}
