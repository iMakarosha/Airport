using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class waypoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Waypoints");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Waypoints",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Waypoints",
                newName: "Time");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Waypoints",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
