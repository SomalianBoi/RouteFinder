using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finder.Domain.Entities;

namespace Finder.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var airlineId = Guid.NewGuid();
            var sourceAirportId = Guid.NewGuid();
            var destinationAirportId = Guid.NewGuid();
            var planeId = Guid.NewGuid();
            var flightId = Guid.NewGuid();
            // Airline Configuration
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(a => a.AirlineId); // Primary Key
                entity.Property(a => a.Name).IsRequired();
                entity.Property(a => a.Alias).IsRequired();
                entity.Property(a => a.IATA).IsRequired().HasMaxLength(2);
                entity.Property(a => a.ICAO).IsRequired().HasMaxLength(3);
                entity.Property(a => a.Callsign).IsRequired();
                entity.Property(a => a.Country).HasMaxLength(100);
                entity.Property(a => a.IsActive).IsRequired();

                // One-to-Many relationship with Flights
                entity.HasMany(a => a.Flights)
                      .WithOne(f => f.airline)
                      .HasForeignKey(f => f.AirlineId)
                      .OnDelete(DeleteBehavior.Restrict); // No cascade delete

                entity.HasData(new Airline
                {
                    AirlineId = airlineId,
                    Name = "Example Airline",
                    Alias = "EA",
                    IATA = "EX",
                    ICAO = "EXA",
                    Callsign = "EXAMPLE",
                    Country = "USA",
                    IsActive = true
                });
            });

            // Airport Configuration
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(a => a.AirportId); // Primary Key
                entity.Property(a => a.Name).IsRequired().HasMaxLength(200);
                entity.Property(a => a.City).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Country).IsRequired().HasMaxLength(100);
                entity.Property(a => a.IataCode).IsRequired().HasMaxLength(3);
                entity.Property(a => a.IcaoCode).IsRequired().HasMaxLength(4);
                entity.Property(a => a.Latitude).IsRequired();
                entity.Property(a => a.Longitude).IsRequired();
                entity.Property(a => a.Altitude).IsRequired();
                entity.Property(a => a.Timezone).IsRequired();

                // Relationships with Flights
                entity.HasMany(a => a.DepartingFlights)
                      .WithOne(f => f.SourceAirportNavigation)
                      .HasForeignKey(f => f.SourceAirportId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(a => a.ArrivingFlights)
                      .WithOne(f => f.DestinationAirportNavigation)
                      .HasForeignKey(f => f.DestinationAirportId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
              new Airport
              {
                  AirportId = sourceAirportId,
                  Name = "John F. Kennedy International Airport",
                  City = "New York",
                  Country = "USA",
                  IataCode = "JFK",
                  IcaoCode = "KJFK",
                  Latitude = 40.6413111,
                  Longitude = -73.7781391,
                  Altitude = 13,
                  Timezone = -5
              },
              new Airport
              {
                  AirportId = destinationAirportId,
                  Name = "Los Angeles International Airport",
                  City = "Los Angeles",
                  Country = "USA",
                  IataCode = "LAX",
                  IcaoCode = "KLAX",
                  Latitude = 33.9416,
                  Longitude = -118.4085,
                  Altitude = 125,
                  Timezone = -8
              });
            });
            // Plane Configuration
            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasKey(p => p.PlaneId); // Primary Key
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.IATACode).IsRequired().HasMaxLength(3);
                entity.Property(p => p.ICAOCode).IsRequired().HasMaxLength(4);

                // One-to-Many relationship with Flights
                entity.HasMany(p => p.Flights)
                      .WithOne(f => f.plane)
                      .HasForeignKey(f => f.PlaneId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(new Plane
                {
                    PlaneId = planeId,
                    Name = "Boeing 737",
                    IATACode = "73G",
                    ICAOCode = "B737"
                });
            });

            // Flight Configuration
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(f => f.FlightId); // Primary Key
                entity.Property(f => f.Stops).IsRequired().HasDefaultValue(0);

                // Foreign Key to Airline
                entity.HasOne(f => f.airline)
                      .WithMany(a => a.Flights)
                      .HasForeignKey(f => f.AirlineId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Foreign Key to Source Airport
                entity.HasOne(f => f.SourceAirportNavigation)
                      .WithMany(a => a.DepartingFlights)
                      .HasForeignKey(f => f.SourceAirportId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Foreign Key to Destination Airport
                entity.HasOne(f => f.DestinationAirportNavigation)
                      .WithMany(a => a.ArrivingFlights)
                      .HasForeignKey(f => f.DestinationAirportId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Foreign Key to Plane
                entity.HasOne(f => f.plane)
                      .WithMany(p => p.Flights)
                      .HasForeignKey(f => f.PlaneId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(new Flight
                {
                    FlightId = flightId,
                    AirlineId = airlineId,
                    SourceAirportId = sourceAirportId,
                    DestinationAirportId = destinationAirportId,
                    PlaneId = planeId,
                    Stops = 0,
                    DurationInMinutes = 380
                });
            });
        }
    }
}
