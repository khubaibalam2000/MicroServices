using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminEventBooking.Migrations
{
    public partial class _21 : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
