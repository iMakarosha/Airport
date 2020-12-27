using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class remove_salon1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceBetweenSeats",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "SeatingDiagram",
                table: "Aircrafts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistanceBetweenSeats",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeatingDiagram",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
