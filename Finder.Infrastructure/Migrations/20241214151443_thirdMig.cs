using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thirdMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "AirlineId", "Alias", "Callsign", "Country", "IATA", "ICAO", "IsActive", "Name" },
                values: new object[] { new Guid("8936f2ce-b062-49df-a601-b80c940cdfb7"), "EA", "EXAMPLE", "USA", "EX", "EXA", true, "Example Airline" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "Altitude", "City", "Country", "Dst", "IataCode", "IcaoCode", "Latitude", "Longitude", "Name", "Source", "Timezone", "Type", "TzDatabaseTimezone" },
                values: new object[,]
                {
                    { new Guid("3e2a9dea-831c-4b00-b0a7-494b79a6e36c"), 125, "Los Angeles", "USA", null, "LAX", "KLAX", 33.941600000000001, -118.4085, "Los Angeles International Airport", null, -8.0, null, null },
                    { new Guid("e580fad6-b0df-4a66-8ef5-949d37ad0791"), 13, "New York", "USA", null, "JFK", "KJFK", 40.641311100000003, -73.778139100000004, "John F. Kennedy International Airport", null, -5.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlaneId", "IATACode", "ICAOCode", "Name" },
                values: new object[] { new Guid("151ec7b6-122c-4267-a89a-655fc7c0a847"), "73G", "B737", "Boeing 737" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AirlineId", "DestinationAirportId", "DurationInMinutes", "PlaneId", "SourceAirportId" },
                values: new object[] { new Guid("b6429e26-b92d-4916-baf7-b86d91124876"), new Guid("8936f2ce-b062-49df-a601-b80c940cdfb7"), new Guid("3e2a9dea-831c-4b00-b0a7-494b79a6e36c"), 380, new Guid("151ec7b6-122c-4267-a89a-655fc7c0a847"), new Guid("e580fad6-b0df-4a66-8ef5-949d37ad0791") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: new Guid("b6429e26-b92d-4916-baf7-b86d91124876"));

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "AirlineId",
                keyValue: new Guid("8936f2ce-b062-49df-a601-b80c940cdfb7"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("3e2a9dea-831c-4b00-b0a7-494b79a6e36c"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("e580fad6-b0df-4a66-8ef5-949d37ad0791"));

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "PlaneId",
                keyValue: new Guid("151ec7b6-122c-4267-a89a-655fc7c0a847"));

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
    }
}
