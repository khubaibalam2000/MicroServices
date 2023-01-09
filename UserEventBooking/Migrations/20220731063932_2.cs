using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserEventBooking.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organzationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.eventId);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Event_eventId",
                        column: x => x.eventId,
                        principalTable: "Event",
                        principalColumn: "eventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_eventId",
                table: "Booking",
                column: "eventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
