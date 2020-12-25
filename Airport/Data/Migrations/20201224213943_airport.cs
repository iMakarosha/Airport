using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Data.Migrations
{
    public partial class airport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonusCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<double>(nullable: false),
                    BonusPersent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight_Rates",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false),
                    RateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_Rates", x => new { x.FlightId, x.RateId });
                });

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

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Cancellble = table.Column<bool>(nullable: false),
                    Returnable = table.Column<bool>(nullable: false),
                    BaggageDimensions = table.Column<string>(nullable: false),
                    ServiceClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftId = table.Column<int>(nullable: false),
                    SeatingDiagram = table.Column<string>(nullable: false),
                    DistanceBetweenSeats = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waypoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 80, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Airport = table.Column<string>(maxLength: 80, nullable: false),
                    Terminal = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waypoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    Patronumic = table.Column<string>(maxLength: 100, nullable: true),
                    SecondName = table.Column<string>(maxLength: 80, nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Citizenship = table.Column<string>(nullable: true, defaultValue: "Россия"),
                    Gender = table.Column<int>(nullable: false, defaultValue: 0),
                    Age = table.Column<int>(nullable: false, defaultValue: 0),
                    PasswordHash = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    BonusCardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_BonusCards_BonusCardId",
                        column: x => x.BonusCardId,
                        principalTable: "BonusCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    Patronumic = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: false),
                    EmploymentDate = table.Column<DateTime>(nullable: false),
                    Passport = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TailNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    CommissioningYear = table.Column<DateTime>(nullable: false),
                    Lifetime = table.Column<int>(nullable: false),
                    Readiness = table.Column<string>(nullable: false),
                    SalonId = table.Column<int>(nullable: false),
                    SalonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircrafts_AircraftModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "AircraftModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aircrafts_Salons_SalonId1",
                        column: x => x.SalonId1,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salon_ServiceClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalonId = table.Column<int>(nullable: false),
                    ServiceClass = table.Column<int>(nullable: false),
                    CountSeating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salon_ServiceClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salon_ServiceClasses_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentType = table.Column<int>(maxLength: 30, nullable: false),
                    Value = table.Column<string>(maxLength: 20, nullable: false),
                    PassengerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftId = table.Column<int>(nullable: false),
                    SkipperId = table.Column<int>(nullable: true),
                    PilotId = table.Column<int>(nullable: true),
                    AirlineId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StartingPointId = table.Column<int>(nullable: true),
                    TermitationPointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Employees_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Employees_SkipperId",
                        column: x => x.SkipperId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Waypoints_StartingPointId",
                        column: x => x.StartingPointId,
                        principalTable: "Waypoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Waypoints_TermitationPointId",
                        column: x => x.TermitationPointId,
                        principalTable: "Waypoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightId = table.Column<int>(nullable: false),
                    PassengerId = table.Column<int>(nullable: false),
                    CashierId = table.Column<int>(nullable: false),
                    PaymentInfo = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Employees_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardingPasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Seat = table.Column<string>(maxLength: 10, nullable: false),
                    TicketId = table.Column<int>(nullable: true),
                    DispatcherId = table.Column<int>(nullable: true),
                    Salon_ServiceClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingPasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardingPasses_Employees_DispatcherId",
                        column: x => x.DispatcherId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardingPasses_salon_ServiceClasses_Salon_ServiceClassId",
                        column: x => x.Salon_ServiceClassId,
                        principalTable: "salon_ServiceClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardingPasses_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_ModelId",
                table: "Aircrafts",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_SalonId1",
                table: "Aircrafts",
                column: "SalonId1");

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPasses_DispatcherId",
                table: "BoardingPasses",
                column: "DispatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPasses_Salon_ServiceClassId",
                table: "BoardingPasses",
                column: "Salon_ServiceClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPasses_TicketId",
                table: "BoardingPasses",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_PassengerId",
                table: "Document",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftId",
                table: "Flights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId",
                table: "Flights",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_SkipperId",
                table: "Flights",
                column: "SkipperId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StartingPointId",
                table: "Flights",
                column: "StartingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TermitationPointId",
                table: "Flights",
                column: "TermitationPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BonusCardId",
                table: "Passengers",
                column: "BonusCardId");

            migrationBuilder.CreateIndex(
                name: "IX_salon_ServiceClasses_SalonId",
                table: "salon_ServiceClasses",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CashierId",
                table: "Tickets",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardingPasses");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Flight_Rates");

            migrationBuilder.DropTable(
                name: "Passenger_Document");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "salon_ServiceClasses");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Waypoints");

            migrationBuilder.DropTable(
                name: "BonusCards");

            migrationBuilder.DropTable(
                name: "AircraftModels");

            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
