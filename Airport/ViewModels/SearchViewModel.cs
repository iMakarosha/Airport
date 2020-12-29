using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models;
using Airport.Models.Flight;
using Airport.Models.AircraftFleet;
using Airport.Models.Customer;

namespace Airport.ViewModels
{
    public class SearchViewModel
    {
        public FilterMain FilterMain { get; set; } 
        public FilterCustom FilterCustom { get; set; }
        public IQueryable<FlightByFilter> Flights { get; set; }
        public List<ServiceClassesFilter> ServiceClass { get; set; }

    }

    public class FilterMain
    {
        public string StartingPoint { get; set; }
        public string TermitationPoint { get; set; }
        public DateTime Date { get; set; }
        public List<ServiceClass> ServiceClass { get; set; }
    }

    public class ServiceClassesFilter
    {
        public int ServiceClassValue { get; set; }
        public string ServiceClassName { get; set; }
    }

    public class FilterCustom
    {
        public int AirlineId { get; set; }
        public int AircraftModelId { get; set; }
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
        public bool Cancellble { get; set; }
        public bool Returnable { get; set; }
    }

    public class FlightByFilter
    {
        public int FlightId { get; set; }
        public int RateId { get; set; }
        public Aircraft Aircraft { get; set; }
        public string AircraftModel { get; set; }
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public Waypoint StartingPoint { get; set; }
        public Waypoint TermitationPoint { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public bool Cancellble { get; set; }
        public bool Returnable { get; set; }
        public string BaggageDimensions { get; set; }
        public ServiceClass ServiceClass { get; set; }
        public int LeftPlaces { get; set; }
    }

    public class ManualFilters
    {
        public FlightFilter FlightFilter { get; set; }
        public TicketFilter TicketFilter { get; set; }
        public PassengerFilter PassengerFilter { get; set; }
    }

    public class FlightFilter
    {
        public string StartingPoint { get; set; }
        public string TermitationPoint { get; set; }
        public DateTime Date { get; set; }
    }

    public class TicketFilter
    {
        public DateTime Date { get; set; }
        public int TicketId { get; set; }
        public string PassengerSurname { get; set; }
        public string PassengerDocumentValue { get; set; }

    }
    public class PassengerFilter
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DocumentValue { get; set; }
        public string Email { get; set; }
    }
}
