using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Airport.ViewModels;
using Airport.Services;
using Airport.Data;
using Airport.Handlers;
using Airport.Models.Customer;

namespace Airport.Controllers
{
    [Authorize(Roles = "cashier")]
    public class CashierController : Controller
    {
        ApplicationDbContext db;
        public CashierController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(new ManualFilters());
        }

        public IActionResult Search(FilterMain filterMain)
        {
            SearchViewModel model = new SearchViewModel();

            if (model.ServiceClass == null)
            {
                model.ServiceClass = new SearchService(db).GetServiceClasses();
            }

            //if (new FilterHandler().IsEmptyFilter(filterMain) && !(new FilterHandler().IsEmptyFilter(oldFilterMain)))
            //{
            //    model.FilterMain = oldFilterMain;
            //}
            //else
            //{
                model.FilterMain = filterMain; 
            //    oldFilterMain = model.FilterMain;
            //}

            //if (new FilterHandler().IsEmptyFilter(filterCustom) && !(new FilterHandler().IsEmptyFilter(oldFilterCustom)))
            //{
            //    model.FilterCustom = oldFilterCustom;
            //}
            //else
            //{
            //    model.FilterCustom = filterCustom;
            //    oldFilterCustom = filterCustom;
            //}

            if (!(new FilterHandler().IsEmptyFilter(model.FilterMain)))
            {
                model.Flights = new SearchService(db).GetSearchViewModel(filterMain);
            }

            return View(model);
        }

        public IActionResult Filters()
        {
            return PartialView("_Filters");
        }


        public IActionResult FlightInfo(FlightByFilter model)
        {
            return PartialView("_FlightInfo", model);
        }
        
        public IActionResult FlightsByFilter()
        {
            var model = new CashierService(db).GetFlightsByFilter();
            return PartialView("_FlightsByFilter", model);
        }
        [HttpPost]
        public IActionResult FlightsByFilter(FlightFilter filter)
        {
            var model = new CashierService(db).GetFlightsByFilter(filter);
            return PartialView("_FlightsByFilter", model);
        }

        public IActionResult PassengersByFilter()
        {
            var model = new CashierService(db).GetPassengersByFilter();
            return PartialView("_PassengersByFilter", model);
        }

        [HttpPost]
        public IActionResult PassengersByFilter(PassengerFilter filter)
        {
            var model = new CashierService(db).GetPassengersByFilter(filter);
            return PartialView("_PassengersByFilter", model);
        }
        public IActionResult TicketsByFilter()
        {
            var model = new CashierService(db).GetTicketsByFilter();
            return PartialView("_TicketsByFilter", model);
        }

        [HttpPost]
        public IActionResult TicketsByFilter(TicketFilter filter)
        {
            var model = new CashierService(db).GetTicketsByFilter(filter);
            return PartialView("_TicketsByFilter", model);
        }
        
        [HttpPost]
        public IActionResult TicketRemove(int ticketId, int pageIdent, string pageName)
        {
            new TicketHandler(db).RemoveTicket(ticketId);
            switch (pageName)
            {
                case "FlightsItem":
                    return RedirectToAction("FlightsItem", "Cashier", new { flightId = pageIdent });
                case "PassengerItem":
                    return RedirectToAction("PassengerItem", "Cashier", new { passengerId = pageIdent });
                default:
                    return RedirectToAction("Index", "Cashier");
            }
        }
        [HttpGet]
        public IActionResult FlightsItem(int flightId)
        {
            var model = new CashierService(db).GetFlightsItem(flightId);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTicket(int FlightId, int RateId)
        {
            AddTicketViewModel model = new TicketService(db).GetTicketViewModel(FlightId, RateId);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTicket(NewTicket ticket)
        {
            //проверить, сохранить, редиректнуть на "Спасибо"
            ticket.CashierName = User.Identity.Name;
            var result = new TicketService(db).AddNewTicket(ticket);
            if (result.IndexOf("Ok") == 0)
            {
                string[] resultItems = result.Split(",");
                new TicketHandler(db).WaitPaymentAsync(Convert.ToInt32(resultItems[1]));
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public IActionResult PassengerItem(int passengerId)
        {
            PassengerFullInfo model = new CashierService(db).GetPassengersItem(passengerId);
            return View(model);
        }

        [HttpPost]
        public IActionResult PassengerItem(UpdatePassenger passengerItem)
        {
            var result = new CashierService(db).SavePassenger(passengerItem);
            return RedirectToAction("PassengerItem", "Cashier", new { passengerId = passengerItem.PassengerId });
        }
        [HttpGet]
        public IActionResult TicketItem(int ticketId)
        {
            var model = new CashierService(db).GetTicketsItem(ticketId);
            return View(model);
        }

        [HttpPost]
        public IActionResult TicketPaid(int ticketId)
        {
            new TicketService(db).UpdateTicket(ticketId);
            return RedirectToAction("TicketItem", "Cashier", new { ticketId });
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
       

        public IActionResult Report()
        {
            return View();
        }
    }
}