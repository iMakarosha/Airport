using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airport.Models.Flight;
using Airport.Models.Worker;

namespace Airport.Models.Customer
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public int FlightId { get; set; }
        public Models.Flight.Flight Flight{ get; set; }
        public int RateId { get; set; }
        public Rate Rate { get; set; }
        [Required]
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        [Required]
        public string CashierId { get; set; }
        public Employee Cashier{ get; set; }
        public string PaymentInfo { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public string PdfFilePath { get; set; }
    }
}
