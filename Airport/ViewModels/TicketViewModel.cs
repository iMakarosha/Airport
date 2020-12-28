using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models.Customer;

namespace Airport.ViewModels
{
    public class NewTicket
    {
        //создать или обновить пользователя
        //добавить или обновить документ
        //создать билет
        public Passenger Passenger { get; set; }
        public TicketDocument Document { get; set; }
        public int FlightId { get; set; }
        public int RateId { get; set; }
        public string CashierName{ get; set; }
        public string PaymentInfo { get; set; }
    }

    public class TicketInfo
    {
        public Ticket Ticket { get; set; }
        public Passenger Passenger { get; set; }
    }
}
