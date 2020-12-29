using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airport.Models;
using Airport.Data;
using Microsoft.AspNetCore.Identity;

namespace Airport.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        [HttpPost]
        public IActionResult SaveForm()
        {
            return Json(new { test = "this is a test" });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginIndex()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("cashier"))
                {
                    return RedirectToAction("Index", "Cashier");
                }
                if (User.IsInRole("administrator"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                if (User.IsInRole("dispatcher"))
                {
                    return RedirectToAction("Index", "Dispatcher");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.BonusCardId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Models.Customer.BonusCard bonusCard)
        {
            db.BonusCards.Update(bonusCard);
            db.SaveChanges();
            return "Thanks!";
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
