using HotelManagementAPI.Contracts;
using HotelManagementAPI.Data;

namespace HotelManagementAPI.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelManagementDbContext context) : base(context) { }
    }
}
