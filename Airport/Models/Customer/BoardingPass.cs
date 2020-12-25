using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airport.Models.Flight;
using Airport.Models.Worker;
using Airport.Models.AircraftFleet;

namespace Airport.Models.Customer
{
    public class BoardingPass
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [MaxLength(10)]
        public string Seat { get; set; }

        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int? DispatcherId { get; set; }
        public Employee Dispatcher { get; set; }

        public int? Salon_ServiceClassId { get; set; }
        public Salon_ServiceClass Salon_ServiceClass{ get; set; }
    }
}
