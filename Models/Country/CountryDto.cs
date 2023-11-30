using HotelManagementAPI.Models.Hotel;

namespace HotelManagementAPI.Models.Country
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}
