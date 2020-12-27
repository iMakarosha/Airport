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
        FilterMain oldFilterMain;
        FilterCustom oldFilterCustom;
        public CashierController(ApplicationDbContext context)
        {
            db = context;
            oldFilterMain = new FilterMain();
            oldFilterCustom = new FilterCustom();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(FilterMain filterMain, FilterCustom filterCustom)
        {
            SearchViewModel model = new SearchViewModel();

            if (model.ServiceClass == null)
            {
                model.ServiceClass = new SearchService(db).GetServiceClasses();
            }

            if (new FilterHandler().IsEmptyFilter(filterMain) && !(new FilterHandler().IsEmptyFilter(oldFilterMain)))
            {
                model.FilterMain = oldFilterMain;
            }
            else
            {
                model.FilterMain = filterMain; 
                oldFilterMain = model.FilterMain;
            }

            if (new FilterHandler().IsEmptyFilter(filterCustom) && !(new FilterHandler().IsEmptyFilter(oldFilterCustom)))
            {
                model.FilterCustom = oldFilterCustom;
            }
            else
            {
                model.FilterCustom = filterCustom;
                oldFilterCustom = filterCustom;
            }

            if (!(new FilterHandler().IsEmptyFilter(model.FilterMain)))
            {
                model.Flights = new SearchService(db).GetSearchViewModel(model.FilterMain, model.FilterCustom).ToList();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AddTicket(int FlightId, int RateId)
        {
            ViewBag.asdf = FlightId.ToString() + RateId.ToString();
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