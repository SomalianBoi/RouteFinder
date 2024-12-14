using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: new Guid("bfc2cdd0-a8db-4bb5-9e11-64d8acfcef59"));

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "AirlineId",
                keyValue: new Guid("10658fbb-5b33-4876-a738-d5dec1ea1053"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("111f9f68-9761-40c3-8e1d-bdf67295164e"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("9b542ab0-4d07-42cd-9ca7-348deec8c3f1"));

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "PlaneId",
                keyValue: new Guid("c80ee1e5-3649-4e5e-a515-e5086d8cc4bd"));

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "AirlineId", "Alias", "Callsign", "Country", "IATA", "ICAO", "IsActive", "Name" },
                values: new object[] { new Guid("cc393269-ccb3-4ac0-8515-8ba6cc727239"), "EA", "EXAMPLE", "USA", "EX", "EXA", true, "Example Airline" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "Altitude", "City", "Country", "Dst", "IataCode", "IcaoCode", "Latitude", "Longitude", "Name", "Source", "Timezone", "Type", "TzDatabaseTimezone" },
                values: new object[,]
                {
                    { new Guid("b86bc10a-7bc3-43a3-99f0-ae88b590e633"), 13, "New York", "USA", null, "JFK", "KJFK", 40.641311100000003, -73.778139100000004, "John F. Kennedy International Airport", null, -5.0, null, null },
                    { new Guid("bfe75d2a-2ac9-4c2c-bcab-3e9ded672ee4"), 125, "Los Angeles", "USA", null, "LAX", "KLAX", 33.941600000000001, -118.4085, "Los Angeles International Airport", null, -8.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlaneId", "IATACode", "ICAOCode", "Name" },
                values: new object[] { new Guid("9bf69dd9-a89b-4e0b-80c2-c5bf3b7310b8"), "73G", "B737", "Boeing 737" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AirlineId", "DestinationAirportId", "DurationInMinutes", "PlaneId", "SourceAirportId" },
                values: new object[] { new Guid("1cda84f3-306a-4d1a-a71a-52d4163f2ec6"), new Guid("cc393269-ccb3-4ac0-8515-8ba6cc727239"), new Guid("bfe75d2a-2ac9-4c2c-bcab-3e9ded672ee4"), 0, new Guid("9bf69dd9-a89b-4e0b-80c2-c5bf3b7310b8"), new Guid("b86bc10a-7bc3-43a3-99f0-ae88b590e633") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: new Guid("1cda84f3-306a-4d1a-a71a-52d4163f2ec6"));

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "AirlineId",
                keyValue: new Guid("cc393269-ccb3-4ac0-8515-8ba6cc727239"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("b86bc10a-7bc3-43a3-99f0-ae88b590e633"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("bfe75d2a-2ac9-4c2c-bcab-3e9ded672ee4"));

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "PlaneId",
                keyValue: new Guid("9bf69dd9-a89b-4e0b-80c2-c5bf3b7310b8"));

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Flights");

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "AirlineId", "Alias", "Callsign", "Country", "IATA", "ICAO", "IsActive", "Name" },
                values: new object[] { new Guid("10658fbb-5b33-4876-a738-d5dec1ea1053"), "EA", "EXAMPLE", "USA", "EX", "EXA", true, "Example Airline" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "Altitude", "City", "Country", "Dst", "IataCode", "IcaoCode", "Latitude", "Longitude", "Name", "Source", "Timezone", "Type", "TzDatabaseTimezone" },
                values: new object[,]
                {
                    { new Guid("111f9f68-9761-40c3-8e1d-bdf67295164e"), 13, "New York", "USA", null, "JFK", "KJFK", 40.641311100000003, -73.778139100000004, "John F. Kennedy International Airport", null, -5.0, null, null },
                    { new Guid("9b542ab0-4d07-42cd-9ca7-348deec8c3f1"), 125, "Los Angeles", "USA", null, "LAX", "KLAX", 33.941600000000001, -118.4085, "Los Angeles International Airport", null, -8.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlaneId", "IATACode", "ICAOCode", "Name" },
                values: new object[] { new Guid("c80ee1e5-3649-4e5e-a515-e5086d8cc4bd"), "73G", "B737", "Boeing 737" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AirlineId", "DestinationAirportId", "PlaneId", "SourceAirportId" },
                values: new object[] { new Guid("bfc2cdd0-a8db-4bb5-9e11-64d8acfcef59"), new Guid("10658fbb-5b33-4876-a738-d5dec1ea1053"), new Guid("9b542ab0-4d07-42cd-9ca7-348deec8c3f1"), new Guid("c80ee1e5-3649-4e5e-a515-e5086d8cc4bd"), new Guid("111f9f68-9761-40c3-8e1d-bdf67295164e") });
        }
    }
}
