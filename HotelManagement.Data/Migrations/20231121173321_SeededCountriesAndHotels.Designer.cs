﻿// <auto-generated />
using HotelManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelManagementAPI.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    [Migration("20231121173321_SeededCountriesAndHotels")]
    partial class SeededCountriesAndHotels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HotelManagementAPI.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New York City",
                            ShortName = "NYC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Los Angeles",
                            ShortName = "LA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chicago",
                            ShortName = "Chi-town"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Houston",
                            ShortName = "H-Town"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Phoenix",
                            ShortName = "PHX"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Philadelphia",
                            ShortName = "Philly"
                        },
                        new
                        {
                            Id = 7,
                            Name = "San Antonio",
                            ShortName = "SA"
                        },
                        new
                        {
                            Id = 8,
                            Name = "San Diego",
                            ShortName = "SD"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Dallas",
                            ShortName = "Big D"
                        },
                        new
                        {
                            Id = 10,
                            Name = "San Francisco",
                            ShortName = "SF"
                        });
                });

            modelBuilder.Entity("HotelManagementAPI.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Negril",
                            CountryId = 1,
                            Name = "Sandals Resort and Spa",
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Address = "George Town",
                            CountryId = 3,
                            Name = "Comfort Suites",
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Address = "Nassau",
                            CountryId = 2,
                            Name = "Grand Palladium",
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 4,
                            Address = "New York City",
                            CountryId = 1,
                            Name = "Marriott Downtown",
                            Rating = 4.7999999999999998
                        },
                        new
                        {
                            Id = 5,
                            Address = "Los Angeles",
                            CountryId = 4,
                            Name = "Hollywood Luxury Inn",
                            Rating = 4.2000000000000002
                        },
                        new
                        {
                            Id = 6,
                            Address = "Chicago",
                            CountryId = 5,
                            Name = "Windy City Suites",
                            Rating = 4.4000000000000004
                        },
                        new
                        {
                            Id = 7,
                            Address = "Houston",
                            CountryId = 6,
                            Name = "Space City Hotel",
                            Rating = 4.0999999999999996
                        },
                        new
                        {
                            Id = 8,
                            Address = "Phoenix",
                            CountryId = 7,
                            Name = "Desert Oasis Resort",
                            Rating = 4.5999999999999996
                        },
                        new
                        {
                            Id = 9,
                            Address = "Philadelphia",
                            CountryId = 8,
                            Name = "Liberty Suites",
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 10,
                            Address = "San Antonio",
                            CountryId = 9,
                            Name = "Alamo View Hotel",
                            Rating = 4.5
                        });
                });

            modelBuilder.Entity("HotelManagementAPI.Data.Hotel", b =>
                {
                    b.HasOne("HotelManagementAPI.Data.Country", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HotelManagementAPI.Data.Country", b =>
                {
                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}
