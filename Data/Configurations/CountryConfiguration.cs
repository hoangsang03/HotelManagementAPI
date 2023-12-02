using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementAPI.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country()
                {
                    Id = 1,
                    Name = "New York City",
                    ShortName = "NYC",
                },
                new Country()
                {
                    Id = 2,
                    Name = "Los Angeles",
                    ShortName = "LA",
                },
                new Country()
                {
                    Id = 3,
                    Name = "Chicago",
                    ShortName = "Chi-town",
                },
                new Country()
                {
                    Id = 4,
                    Name = "Houston",
                    ShortName = "H-Town",
                },
                new Country()
                {
                    Id = 5,
                    Name = "Phoenix",
                    ShortName = "PHX",
                },
                new Country()
                {
                    Id = 6,
                    Name = "Philadelphia",
                    ShortName = "Philly",
                },
                new Country()
                {
                    Id = 7,
                    Name = "San Antonio",
                    ShortName = "SA",
                },
                new Country()
                {
                    Id = 8,
                    Name = "San Diego",
                    ShortName = "SD",
                },
                new Country()
                {
                    Id = 9,
                    Name = "Dallas",
                    ShortName = "Big D",
                },
                new Country()
                {
                    Id = 10,
                    Name = "San Francisco",
                    ShortName = "SF",
                }
            );
        }
    }
}
