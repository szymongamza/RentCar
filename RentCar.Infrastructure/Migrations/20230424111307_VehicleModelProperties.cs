using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehicleModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "CargoCapacity",
                table: "VehicleModels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "VehicleModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Range",
                table: "VehicleModels",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoCapacity",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "Range",
                table: "VehicleModels");

            migrationBuilder.AddColumn<string>(
                name: "Mileage",
                table: "Vehicles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
