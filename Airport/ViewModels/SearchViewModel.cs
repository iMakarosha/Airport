using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models;
using Airport.Models.Flight;
using Airport.Models.AircraftFleet;

namespace Airport.ViewModels
{
    public class SearchViewModel
    {
        public FilterMain FilterMain { get; set; } 
        public FilterCustom FilterCustom { get; set; }
        public IQueryable<FlightByRate> Flights { get; set; }
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

    public class FlightByRate
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
        //public int AllPlaces { get; set; }
        //public int OccupiedPlaces { get; set; }
    }
}
