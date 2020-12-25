using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Airport.Models.Customer;
using Airport.Models.AircraftFleet;
using Airport.Models.Flight;
using Airport.Models.Worker;

namespace Airport.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<BonusCard> BonusCards { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees{ get; set; }

        public DbSet<Salon> Salons { get; set; }
        public DbSet<Salon_ServiceClass> Salon_ServiceClasses { get; set; }
        public DbSet<AircraftModel> AircraftModels { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Waypoint> Waypoints{ get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Flight_Rate> Flight_Rates { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<BoardingPass> BoardingPasses { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight_Rate>().HasKey(fr => new { fr.FlightId, fr.RateId });
            modelBuilder.Entity<Passenger>().Property(p => p.Age).HasDefaultValue(Age.a);
            modelBuilder.Entity<Passenger>().Property(p => p.Gender).HasDefaultValue(Gender.m);
            modelBuilder.Entity<Passenger>().Property(p => p.Citizenship).HasDefaultValue("Россия");

            //modelBuilder.Entity<Flight>().HasOne(f => f.Skipper).WithOne().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Flight>().HasOne(f => f.Pilot).WithOne().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
