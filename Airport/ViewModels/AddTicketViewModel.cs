using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models;
using Airport.Models.Flight;
using Airport.Models.AircraftFleet;

namespace Airport.ViewModels
{
    public class AddTicketViewModel
    {
        public SearchViewModel TicketInfo { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
