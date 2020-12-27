using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Airport.ViewModels;
using Airport.Services;
using Airport.Data;

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

        public IActionResult Search()
        {
            SearchViewModel model = new SearchViewModel();
            model.Flights = new SearchService(db).GetSearchViewModel(new FilterMain { StartingPoint = "", TermitationPoint = "" }).ToList();
            return View(model);
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