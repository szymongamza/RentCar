using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehicleImageByteToStringPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Vehicles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Vehicles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Vehicles",
                type: "BLOB",
                nullable: true);
        }
    }
}
