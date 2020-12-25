using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airport.Models.AircraftFleet;
using Airport.Models.Worker;

namespace Airport.Models.Flight
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        public int? SkipperId { get; set; }
        public Employee Skipper { get; set; }
        public int? PilotId { get; set; }
        public Employee Pilot { get; set; }

        [Required]
        public int AirlineId { get; set; }
        public Airline Airline{ get; set; }

        [Required]
        public Status Status { get; set; }

        public int? StartingPointId { get; set; }
        public Waypoint StartingPoint { get; set; }
        public int? TermitationPointId { get; set; }
        public Waypoint TermitationPoint { get; set; }
    }

    public class Flight_Rate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlightId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RateId { get; set; }
    }

    public enum Status
    {
        [Display(Name = "Вовремя")]
        ontime,
        [Display(Name = "Задерживается")]
        delayed,
        [Display(Name = "Ожидается")]
        expected,
        [Display(Name = "Приземлился")]
        landed
    }
}
