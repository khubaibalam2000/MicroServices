using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserEventBooking.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ratingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(type: "int", nullable: false),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ratingId);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    reviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.reviewId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
