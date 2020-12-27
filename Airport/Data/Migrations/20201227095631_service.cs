using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RateId",
                table: "Tickets",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rates_RateId",
                table: "Tickets",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rates_RateId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RateId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Tickets");
        }
    }
}
