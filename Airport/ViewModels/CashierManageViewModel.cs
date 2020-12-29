using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models;
using Airport.Models.Flight;
using Airport.Models.Customer;
using Airport.Models.AircraftFleet;

namespace Airport.ViewModels
{
    //public class FlightByFilter
    //{
    //    public int FlightId { get; set; }
    //    public int RateId { get; set; }
    //    public Aircraft Aircraft { get; set; }
    //    public string AircraftModel { get; set; }
    //    public int AirlineId { get; set; }
    //    public string AirlineName { get; set; }
    //    public Waypoint StartingPoint { get; set; }
    //    public Waypoint TermitationPoint { get; set; }
    //    public string Name { get; set; }
    //    public double Cost { get; set; }
    //    public bool Cancellble { get; set; }
    //    public bool Returnable { get; set; }
    //    public string BaggageDimensions { get; set; }
    //    public ServiceClass ServiceClass { get; set; }
    //    public int LeftPlaces { get; set; }
    //}

    public class FlightFullInfo
    {
        public FlightByFilter Flight { get; set; }
        public List<TicketFull> Tickets { get; set; }
        public List<Rate> Rates { get; set; }
    }

    public class PassengerFullInfo
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public TicketDocument Document { get; set; }
        public List<TicketFull> Tickets { get; set; }
        public List<EnumList> Genders { get; set; }
        public List<EnumList> Ages { get; set; }
        public List<EnumList> Documents { get; set; }

    }

    public class UpdatePassenger
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public TicketDocument Document { get; set; }
    }
    public class TicketFullInfo
    {
        public TicketFull Ticket { get; set; }
        public Passenger Passenger { get; set; }
        public TicketDocument Document { get; set; }
        public List<EnumList> Genders { get; set; }
        public List<EnumList> Ages { get; set; }
        public List<EnumList> Documents { get; set; }

    }
}
