using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarWatchORM.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suns_Cities_CityId",
                table: "Suns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suns",
                table: "Suns");

            migrationBuilder.RenameTable(
                name: "Suns",
                newName: "SunRecords");

            migrationBuilder.RenameIndex(
                name: "IX_Suns_CityId",
                table: "SunRecords",
                newName: "IX_SunRecords_CityId");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Cities",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Cities",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SunRecords",
                table: "SunRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SunRecords_Cities_CityId",
                table: "SunRecords",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SunRecords_Cities_CityId",
                table: "SunRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SunRecords",
                table: "SunRecords");

            migrationBuilder.RenameTable(
                name: "SunRecords",
                newName: "Suns");

            migrationBuilder.RenameIndex(
                name: "IX_SunRecords_CityId",
                table: "Suns",
                newName: "IX_Suns_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "Longitude",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Latitude",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suns",
                table: "Suns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suns_Cities_CityId",
                table: "Suns",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
