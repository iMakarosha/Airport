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
            return View();
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
            if (result == "Ok")
            {
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Passengers()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }
    }
}