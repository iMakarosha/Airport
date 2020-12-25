using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class document_passenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Passengers_PassengerId",
                table: "Document");

            migrationBuilder.DropTable(
                name: "Passenger_Document");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "Document",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Passengers_PassengerId",
                table: "Document",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Passengers_PassengerId",
                table: "Document");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "Document",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Passenger_Document",
                columns: table => new
                {
                    PassengerId = table.Column<int>(nullable: false),
                    DocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger_Document", x => new { x.PassengerId, x.DocumentId });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Passengers_PassengerId",
                table: "Document",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
