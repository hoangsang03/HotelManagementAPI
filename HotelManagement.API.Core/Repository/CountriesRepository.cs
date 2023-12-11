using HotelManagement.Data.Data;
using HotelManagementAPI.Contracts;
using HotelManagementAPI.Data;
using HotelManagementAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.API.Core.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelManagementDbContext _context;

        public CountriesRepository(HotelManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            Country country = await _context.Countries.Include(c => c.Hotels)
                .FirstOrDefaultAsync(c => c.Id == id);
            return country;
        }
    }
}
