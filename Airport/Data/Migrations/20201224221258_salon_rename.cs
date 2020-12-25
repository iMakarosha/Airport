using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class salon_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPasses_salon_ServiceClasses_Salon_ServiceClassId",
                table: "BoardingPasses");

            migrationBuilder.DropForeignKey(
                name: "FK_salon_ServiceClasses_Salons_SalonId",
                table: "salon_ServiceClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_salon_ServiceClasses",
                table: "salon_ServiceClasses");

            migrationBuilder.RenameTable(
                name: "salon_ServiceClasses",
                newName: "Salon_ServiceClasses");

            migrationBuilder.RenameIndex(
                name: "IX_salon_ServiceClasses_SalonId",
                table: "Salon_ServiceClasses",
                newName: "IX_Salon_ServiceClasses_SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salon_ServiceClasses",
                table: "Salon_ServiceClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPasses_Salon_ServiceClasses_Salon_ServiceClassId",
                table: "BoardingPasses",
                column: "Salon_ServiceClassId",
                principalTable: "Salon_ServiceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_ServiceClasses_Salons_SalonId",
                table: "Salon_ServiceClasses",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPasses_Salon_ServiceClasses_Salon_ServiceClassId",
                table: "BoardingPasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Salon_ServiceClasses_Salons_SalonId",
                table: "Salon_ServiceClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salon_ServiceClasses",
                table: "Salon_ServiceClasses");

            migrationBuilder.RenameTable(
                name: "Salon_ServiceClasses",
                newName: "salon_ServiceClasses");

            migrationBuilder.RenameIndex(
                name: "IX_Salon_ServiceClasses_SalonId",
                table: "salon_ServiceClasses",
                newName: "IX_salon_ServiceClasses_SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salon_ServiceClasses",
                table: "salon_ServiceClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPasses_salon_ServiceClasses_Salon_ServiceClassId",
                table: "BoardingPasses",
                column: "Salon_ServiceClassId",
                principalTable: "salon_ServiceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salon_ServiceClasses_Salons_SalonId",
                table: "salon_ServiceClasses",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
