﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Airport.Data;
using Airport.Models.Customer;

namespace Airport.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Airport.Models.AircraftFleet.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommissioningYear");

                    b.Property<int>("Lifetime");

                    b.Property<int>("ModelId");

                    b.Property<DateTime>("ProductionDate");

                    b.Property<int>("Readiness");

                    b.Property<string>("TailNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("Airport.Models.AircraftFleet.AircraftModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("AircraftModels");
                });

            modelBuilder.Entity("Airport.Models.AircraftFleet.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId");

                    b.Property<string>("DistanceBetweenSeats")
                        .IsRequired();

                    b.Property<string>("SeatingDiagram")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AircraftId")
                        .IsUnique();

                    b.ToTable("Salons");
                });

            modelBuilder.Entity("Airport.Models.AircraftFleet.Salon_ServiceClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountSeating");

                    b.Property<int>("SalonId");

                    b.Property<int>("ServiceClass");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("Salon_ServiceClasses");
                });

            modelBuilder.Entity("Airport.Models.Customer.BoardingPass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("DispatcherId");

                    b.Property<int?>("Salon_ServiceClassId");

                    b.Property<string>("Seat")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int?>("TicketId");

                    b.HasKey("Id");

                    b.HasIndex("DispatcherId");

                    b.HasIndex("Salon_ServiceClassId");

                    b.HasIndex("TicketId");

                    b.ToTable("BoardingPasses");
                });

            modelBuilder.Entity("Airport.Models.Customer.BonusCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance");

                    b.Property<int>("BonusPersent");

                    b.HasKey("Id");

                    b.ToTable("BonusCards");
                });

            modelBuilder.Entity("Airport.Models.Customer.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocumentType")
                        .HasMaxLength(30);

                    b.Property<int>("PassengerId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Airport.Models.Customer.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime>("Birthday");

                    b.Property<int?>("BonusCardId");

                    b.Property<string>("Citizenship")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Россия");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Notes");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Patronumic")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("SecondName")
                        .HasMaxLength(80);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BonusCardId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Airport.Models.Customer.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CashierId");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("FlightId");

                    b.Property<int>("PassengerId");

                    b.Property<string>("PaymentInfo");

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Airport.Models.Flight.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("Airport.Models.Flight.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId");

                    b.Property<int>("AirlineId");

                    b.Property<int?>("PilotId");

                    b.Property<int?>("SkipperId");

                    b.Property<int?>("StartingPointId");

                    b.Property<int>("Status");

                    b.Property<int?>("TermitationPointId");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("PilotId");

                    b.HasIndex("SkipperId");

                    b.HasIndex("StartingPointId");

                    b.HasIndex("TermitationPointId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Airport.Models.Flight.Flight_Rate", b =>
                {
                    b.Property<int>("FlightId");

                    b.Property<int>("RateId");

                    b.HasKey("FlightId", "RateId");

                    b.ToTable("Flight_Rates");
                });

            modelBuilder.Entity("Airport.Models.Flight.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BaggageDimensions")
                        .IsRequired();

                    b.Property<bool>("Cancellble");

                    b.Property<double>("Cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Returnable");

                    b.Property<int>("ServiceClass");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("Airport.Models.Flight.Waypoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Airport")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Notes");

                    b.Property<int>("Terminal");

                    b.HasKey("Id");

                    b.ToTable("Waypoints");
                });

            modelBuilder.Entity("Airport.Models.Worker.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("EmploymentDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Passport");

                    b.Property<string>("Patronumic")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int>("PositionId");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Airport.Models.Worker.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Airport.Models.AircraftFleet.Aircraft", b =>
                {
                    b.HasOne("Airport.Models.AircraftFleet.AircraftModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airport.Models.AircraftFleet.Salon", b =>
                {
                    b.HasOne("Airport.Models.AircraftFleet.Aircraft")
                        .WithOne("Salon")
                        .HasForeignKey("Airport.Models.AircraftFleet.Salon", "AircraftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airport.Models.AircraftFleet.Salon_ServiceClass", b =>
                {
                    b.HasOne("Airport.Models.AircraftFleet.Salon")
                        .WithMany("ServiceClasses")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airport.Models.Customer.BoardingPass", b =>
                {
                    b.HasOne("Airport.Models.Worker.Employee", "Dispatcher")
                        .WithMany()
                        .HasForeignKey("DispatcherId");

                    b.HasOne("Airport.Models.AircraftFleet.Salon_ServiceClass", "Salon_ServiceClass")
                        .WithMany()
                        .HasForeignKey("Salon_ServiceClassId");

                    b.HasOne("Airport.Models.Customer.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");
                });

            modelBuilder.Entity("Airport.Models.Customer.Document", b =>
                {
                    b.HasOne("Airport.Models.Customer.Passenger", "Passenger")
                        .WithMany("Documents")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airport.Models.Customer.Passenger", b =>
                {
                    b.HasOne("Airport.Models.Customer.BonusCard", "BonusCard")
                        .WithMany()
                        .HasForeignKey("BonusCardId");
                });

            modelBuilder.Entity("Airport.Models.Customer.Ticket", b =>
                {
                    b.HasOne("Airport.Models.Worker.Employee", "Cashier")
                        .WithMany()
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airport.Models.Flight.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airport.Models.Customer.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airport.Models.Flight.Flight", b =>
                {
                    b.HasOne("Airport.Models.AircraftFleet.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airport.Models.Flight.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airport.Models.Worker.Employee", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");

                    b.HasOne("Airport.Models.Worker.Employee", "Skipper")
                        .WithMany()
                        .HasForeignKey("SkipperId");

                    b.HasOne("Airport.Models.Flight.Waypoint", "StartingPoint")
                        .WithMany()
                        .HasForeignKey("StartingPointId");

                    b.HasOne("Airport.Models.Flight.Waypoint", "TermitationPoint")
                        .WithMany()
                        .HasForeignKey("TermitationPointId");
                });

            modelBuilder.Entity("Airport.Models.Worker.Employee", b =>
                {
                    b.HasOne("Airport.Models.Worker.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
