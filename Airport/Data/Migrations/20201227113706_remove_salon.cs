using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class remove_salon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_ServiceClasses_Salons_SalonId",
                table: "Salon_ServiceClasses");

            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.DropIndex(
                name: "IX_Salon_ServiceClasses_SalonId",
                table: "Salon_ServiceClasses");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Salon_ServiceClasses");

            migrationBuilder.AddColumn<int>(
                name: "AircraftId",
                table: "Salon_ServiceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DistanceBetweenSeats",
                table: "Aircrafts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeatingDiagram",
                table: "Aircrafts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salon_ServiceClasses_AircraftId",
                table: "Salon_ServiceClasses",
                column: "AircraftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_ServiceClasses_Aircrafts_AircraftId",
                table: "Salon_ServiceClasses",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_ServiceClasses_Aircrafts_AircraftId",
                table: "Salon_ServiceClasses");

            migrationBuilder.DropIndex(
                name: "IX_Salon_ServiceClasses_AircraftId",
                table: "Salon_ServiceClasses");

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "Salon_ServiceClasses");

            migrationBuilder.DropColumn(
                name: "DistanceBetweenSeats",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "SeatingDiagram",
                table: "Aircrafts");

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Salon_ServiceClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    DistanceBetweenSeats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatingDiagram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salons_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salon_ServiceClasses_SalonId",
                table: "Salon_ServiceClasses",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_AircraftId",
                table: "Salons",
                column: "AircraftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_ServiceClasses_Salons_SalonId",
                table: "Salon_ServiceClasses",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
