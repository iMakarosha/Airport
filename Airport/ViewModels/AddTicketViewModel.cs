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
    public class AddTicketViewModel
    {
        public int FlightId { get; set; }
        public int RateId { get; set; }
        public Passenger Passenger { get; set; }
        public TicketDocument Document { get; set; }
        public FlightByFilter TicketInfo { get; set; }
        public List<Rate> Rates { get; set; }
        public List<EnumList> Genders { get; set; }
        public List<EnumList> Ages { get; set; }
        public List<EnumList> Documents { get; set; }
    }

    public class TicketDocument
    {
        public int Type { get; set; }
        public string Value { get; set; }
    }
    public class EnumList
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}
