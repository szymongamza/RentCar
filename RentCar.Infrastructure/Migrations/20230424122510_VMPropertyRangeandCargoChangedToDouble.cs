using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VMPropertyRangeandCargoChangedToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoCapacity",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "Range",
                table: "VehicleModels");

            migrationBuilder.AddColumn<double>(
                name: "CargoCapacityInLitres",
                table: "VehicleModels",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RangeInKilometers",
                table: "VehicleModels",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoCapacityInLitres",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "RangeInKilometers",
                table: "VehicleModels");

            migrationBuilder.AddColumn<string>(
                name: "CargoCapacity",
                table: "VehicleModels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Range",
                table: "VehicleModels",
                type: "TEXT",
                nullable: true);
        }
    }
}
