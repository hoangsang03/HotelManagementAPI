using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementAPI.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                    new Hotel
                    {
                        Id = 1,
                        Name = "Sandals Resort and Spa",
                        Address = "Negril",
                        CountryId = 1,
                        Rating = 4.5
                    },
                    new Hotel
                    {
                        Id = 2,
                        Name = "Comfort Suites",
                        Address = "George Town",
                        CountryId = 3,
                        Rating = 4.3
                    },
                    new Hotel
                    {
                        Id = 3,
                        Name = "Grand Palladium",
                        Address = "Nassau",
                        CountryId = 2,
                        Rating = 4
                    },
                    new Hotel
                    {
                        Id = 4,
                        Name = "Marriott Downtown",
                        Address = "New York City",
                        CountryId = 1,
                        Rating = 4.8
                    },
                    new Hotel
                    {
                        Id = 5,
                        Name = "Hollywood Luxury Inn",
                        Address = "Los Angeles",
                        CountryId = 4,
                        Rating = 4.2
                    },
                    new Hotel
                    {
                        Id = 6,
                        Name = "Windy City Suites",
                        Address = "Chicago",
                        CountryId = 5,
                        Rating = 4.4
                    },
                    new Hotel
                    {
                        Id = 7,
                        Name = "Space City Hotel",
                        Address = "Houston",
                        CountryId = 6,
                        Rating = 4.1
                    },
                    new Hotel
                    {
                        Id = 8,
                        Name = "Desert Oasis Resort",
                        Address = "Phoenix",
                        CountryId = 7,
                        Rating = 4.6
                    },
                    new Hotel
                    {
                        Id = 9,
                        Name = "Liberty Suites",
                        Address = "Philadelphia",
                        CountryId = 8,
                        Rating = 4.3
                    },
                    new Hotel
                    {
                        Id = 10,
                        Name = "Alamo View Hotel",
                        Address = "San Antonio",
                        CountryId = 9,
                        Rating = 4.5
                    }
                );
        }
    }
}
