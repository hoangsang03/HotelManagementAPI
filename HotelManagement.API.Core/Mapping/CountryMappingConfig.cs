using HotelManagement.Data.Data;
using HotelManagementAPI.Data;
using HotelManagementAPI.Models.Country;
using HotelManagementAPI.Models.Hotel;
using Mapster;

namespace HotelManagement.API.Core.Mapping
{
    public class CountryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Country, CountryDto>().TwoWays();
            config.NewConfig<CreateCountryDto, Country>();
            config.NewConfig<UpdateCountryDto, Country>();
            config.NewConfig<Country, GetCountryDto>();

            config.NewConfig<Hotel, HotelDto>().TwoWays();
            config.NewConfig<CreateHotelDto, Hotel>();
        }
    }
}
