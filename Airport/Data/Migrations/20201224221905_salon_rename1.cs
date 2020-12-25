using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class salon_rename1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_Salons_SalonId1",
                table: "Aircrafts");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_SalonId1",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "SalonId1",
                table: "Aircrafts");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_AircraftId",
                table: "Salons",
                column: "AircraftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salons_Aircrafts_AircraftId",
                table: "Salons",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salons_Aircrafts_AircraftId",
                table: "Salons");

            migrationBuilder.DropIndex(
                name: "IX_Salons_AircraftId",
                table: "Salons");

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Aircrafts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalonId1",
                table: "Aircrafts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_SalonId1",
                table: "Aircrafts",
                column: "SalonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_Salons_SalonId1",
                table: "Aircrafts",
                column: "SalonId1",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
