using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models.Customer;
using Airport.Models.Flight;

namespace Airport.ViewModels
{
    public class NewTicket
    {
        public int FlightId { get; set; }
        public int RateId { get; set; }
        public Passenger Passenger { get; set; }
        public TicketDocument Document { get; set; }
        public string CashierName{ get; set; }
        public string PaymentInfo { get; set; }
    }
    public class TicketFull
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public Rate Rate { get; set; }
        public string CashierName { get; set; }
        public string PaymentInfo { get; set; }
        public string PdfFilePath { get; set; }
    }

    public class TicketInfo
    {
        public TicketFull Ticket { get; set; }
        public Passenger Passenger { get; set; }
    }
}
