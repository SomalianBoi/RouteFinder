using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class forthMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DestinationAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_SourceAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

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
                values: new object[] { new Guid("2eab97ee-0a2a-46d5-a563-a56aa12a74bb"), "EA", "EXAMPLE", "USA", "EX", "EXA", true, "Example Airline" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "Altitude", "City", "Country", "Dst", "IataCode", "IcaoCode", "Latitude", "Longitude", "Name", "Source", "Timezone", "Type", "TzDatabaseTimezone" },
                values: new object[,]
                {
                    { new Guid("b389ca2f-c62a-495f-946c-d646f4b22ff0"), 125, "Los Angeles", "USA", null, "LAX", "KLAX", 33.941600000000001, -118.4085, "Los Angeles International Airport", null, -8.0, null, null },
                    { new Guid("e9c42fb9-a516-482c-8a4d-1b597ea5c2ed"), 13, "New York", "USA", null, "JFK", "KJFK", 40.641311100000003, -73.778139100000004, "John F. Kennedy International Airport", null, -5.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlaneId", "IATACode", "ICAOCode", "Name" },
                values: new object[] { new Guid("506fdf88-ed38-49bb-9075-2ec2da497826"), "73G", "B737", "Boeing 737" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AirlineId", "DestinationAirportId", "DurationInMinutes", "PlaneId", "SourceAirportId" },
                values: new object[] { new Guid("ac426ace-9e39-4438-8b72-e042c1101027"), new Guid("2eab97ee-0a2a-46d5-a563-a56aa12a74bb"), new Guid("b389ca2f-c62a-495f-946c-d646f4b22ff0"), 380, new Guid("506fdf88-ed38-49bb-9075-2ec2da497826"), new Guid("e9c42fb9-a516-482c-8a4d-1b597ea5c2ed") });

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "AirlineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DestinationAirportId",
                table: "Flights",
                column: "DestinationAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_SourceAirportId",
                table: "Flights",
                column: "SourceAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DestinationAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_SourceAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: new Guid("ac426ace-9e39-4438-8b72-e042c1101027"));

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "AirlineId",
                keyValue: new Guid("2eab97ee-0a2a-46d5-a563-a56aa12a74bb"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("b389ca2f-c62a-495f-946c-d646f4b22ff0"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: new Guid("e9c42fb9-a516-482c-8a4d-1b597ea5c2ed"));

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "PlaneId",
                keyValue: new Guid("506fdf88-ed38-49bb-9075-2ec2da497826"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "AirlineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DestinationAirportId",
                table: "Flights",
                column: "DestinationAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_SourceAirportId",
                table: "Flights",
                column: "SourceAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
