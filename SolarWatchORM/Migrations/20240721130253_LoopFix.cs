using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolarWatchORM.Migrations
{
    /// <inheritdoc />
    public partial class LoopFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SunRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SunRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Latitude", "Longitude", "Name", "State" },
                values: new object[,]
                {
                    { 1, "England", 51.509864999999998, -0.118092, "London", "London" },
                    { 2, "Hungary", 47.497912999999997, 19.040236, "Budapest", "Pest" },
                    { 3, "France", 48.864716000000001, 2.3490139999999999, "Paris", "Paris" }
                });

            migrationBuilder.InsertData(
                table: "SunRecords",
                columns: new[] { "Id", "CityId", "Sunrise", "Sunset" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 18, 5, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 18, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 7, 18, 5, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 18, 20, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
