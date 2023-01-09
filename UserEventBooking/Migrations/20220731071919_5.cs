using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserEventBooking.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Event_eventId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Booking_eventId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "eventId",
                table: "Booking");

            migrationBuilder.AddColumn<string>(
                name: "eventName",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventName",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "eventId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organzationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    venue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.eventId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_eventId",
                table: "Booking",
                column: "eventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Event_eventId",
                table: "Booking",
                column: "eventId",
                principalTable: "Event",
                principalColumn: "eventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
