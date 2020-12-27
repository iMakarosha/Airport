using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class remove_salon2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistanceBetweenSeats",
                table: "Aircrafts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeatingDiagram",
                table: "Aircrafts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceBetweenSeats",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "SeatingDiagram",
                table: "Aircrafts");
        }
    }
}
