using HotelManagementAPI.Data;

namespace HotelManagement.Data.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public virtual IList<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}