using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class add_ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_CashierId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CashierId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Passengers");

            migrationBuilder.AlterColumn<string>(
                name: "CashierId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CashierId1",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CashierId1",
                table: "Tickets",
                column: "CashierId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_CashierId1",
                table: "Tickets",
                column: "CashierId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_CashierId1",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CashierId1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CashierId1",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "CashierId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Passengers",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CashierId",
                table: "Tickets",
                column: "CashierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_CashierId",
                table: "Tickets",
                column: "CashierId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
