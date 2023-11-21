using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // it does nothing
            modelBuilder.Entity<Country>().HasData(
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
            modelBuilder.Entity<Hotel>().HasData(
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
