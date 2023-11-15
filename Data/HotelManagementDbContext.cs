using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions options) : base(options)
        {


        }
    }
}
