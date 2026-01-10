using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSI.Airbook.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightDao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureFrom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ArrivalTo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalSeats = table.Column<int>(type: "integer", nullable: false),
                    AvailableSeats = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PlaneNumber = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DirectFlight = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassportNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingDao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    NumberOfKg = table.Column<int>(type: "integer", nullable: true),
                    CheckingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CancellationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingDao_FlightDao_FlightId",
                        column: x => x.FlightId,
                        principalTable: "FlightDao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDao_PassengerDao_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "PassengerDao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDao_FlightId",
                table: "BookingDao",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDao_PassengerId",
                table: "BookingDao",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDao");

            migrationBuilder.DropTable(
                name: "FlightDao");

            migrationBuilder.DropTable(
                name: "PassengerDao");
        }
    }
}
