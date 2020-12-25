using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class airline_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Readiness",
                table: "Aircrafts",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Readiness",
                table: "Aircrafts",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
