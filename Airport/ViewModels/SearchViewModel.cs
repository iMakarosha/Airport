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
        public int FilterMain { get; set; } 
        public FilterCustom FilterCustom { get; set; }
        public List<FlightByRate> Flights { get; set; }
    }

    public class FilterMain
    {
        public string StartingPoint { get; set; }
        public string TermitationPoint { get; set; }
        public DateTime Date { get; set; }
        public ServiceClass ServiceClass { get; set; }
    }

    public class FilterCustom
    {
        public Airline Airlines { get; set; }
        public AircraftModel AircraftModels { get; set; }
        public double Cost { get; set; }
        public bool Cancellble { get; set; }
        public bool Returnable { get; set; }
    }

    public class FlightByRate
    {
        public Aircraft Aircraft { get; set; }
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
    }
}
