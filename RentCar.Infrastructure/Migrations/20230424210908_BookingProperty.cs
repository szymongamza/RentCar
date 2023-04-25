using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookingProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Offices_OfficeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_OfficeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Vehicles");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    PickUpOfficeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DropOffOfficeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DropOffTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalCost = table.Column<double>(type: "REAL", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    UserSurname = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Offices_DropOffOfficeId",
                        column: x => x.DropOffOfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Offices_PickUpOfficeId",
                        column: x => x.PickUpOfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DropOffOfficeId",
                table: "Bookings",
                column: "DropOffOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PickUpOfficeId",
                table: "Bookings",
                column: "PickUpOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleId",
                table: "Bookings",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Vehicles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OfficeId",
                table: "Vehicles",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Offices_OfficeId",
                table: "Vehicles",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");
        }
    }
}
