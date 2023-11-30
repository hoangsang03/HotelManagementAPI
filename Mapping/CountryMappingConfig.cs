using HotelManagementAPI.Data;
using HotelManagementAPI.Models.Country;
using HotelManagementAPI.Models.Hotel;
using Mapster;

namespace HotelManagementAPI.Mapping
{
    public class CountryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Country, CountryDto>();
            config.NewConfig<Country, CreateCountryDto>();
            config.NewConfig<Country, UpdateCountryDto>();
            config.NewConfig<Country, GetCountryDto>();

            config.NewConfig<Hotel, HotelDto>();
        }
    }
}
