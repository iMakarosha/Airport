using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Data;
using Airport.Models;
using Airport.ViewModels;
using Airport.Models.AircraftFleet;
using Airport.Models.Flight;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airport.Services
{
    public class SearchService:Controller
    {
        ApplicationDbContext db;

        public SearchService(ApplicationDbContext context)
        {
            db = context;
        }


        public IEnumerable<FlightByRate> GetSearchViewModel(FilterMain filter)
        {
            //db.Flights.Where(f => EF.Functions.Like(f.StartingPoint.City, "%" + filter.StartingPoint + "%") &&
            //                      EF.Functions.Like(f.TermitationPoint.City, "%" + filter.TermitationPoint + "%"))
            //    .Join()
            //    .Select(f=>f).OrderBy(f=>f.Id);
            //var sdf = from flight in db.Flights
            //          join flight_rate in db.Flight_Rates on flight.Id equals flight_rate.FlightId
            //          join rate in db.Rates on flight_rate.RateId equals rate.Id
            //          select new FlightWithRate
            //          {
            //              Flight = new Models.Flight.Flight()
            //              {
            //                  Aircraft = flight.Aircraft
            //              }
            //          };
            //return db.Flights.Where(f => EF.Functions.Like(f.StartingPoint.City, "%" + filter.StartingPoint + "%") &&
            //                      EF.Functions.Like(f.TermitationPoint.City, "%" + filter.TermitationPoint + "%"))
            //    .Select(f => new FlightWithRate
            //    {
            //        Flight = f,
            //        Rates = (from fr in db.Flight_Rates
            //                 join r in db.Rates on fr.RateId equals r.Id
            //                 where fr.FlightId == f.Id
            //                 select r).ToList()
            //    });

            return from f in db.Flights
                     join fr in db.Flight_Rates on f.Id equals fr.FlightId
                     join r in db.Rates on fr.RateId equals r.Id
                     join a in db.Aircrafts on f.AircraftId equals a.Id
                     join am in db.AircraftModels on a.ModelId equals am.Id
                     join airl in db.Airlines on f.AirlineId equals airl.Id
                     where EF.Functions.Like(f.StartingPoint.City, "%" + filter.StartingPoint + "%") &
                                EF.Functions.Like(f.TermitationPoint.City, "%" + filter.TermitationPoint + "%")
                     select new FlightByRate
                     {
                         Aircraft = a,
                         AirlineId = airl.Id,
                         AirlineName = airl.Name,
                         Name = r.Name,
                         Cost = r.Cost,
                         BaggageDimensions = r.BaggageDimensions,
                         Cancellble = r.Cancellble,
                         Returnable = r.Returnable,
                         ServiceClass = r.ServiceClass,
                         StartingPoint = (from wp in db.Waypoints
                                          where wp.Id == f.StartingPointId
                                          select wp).FirstOrDefault(),
                         TermitationPoint = (from wp in db.Waypoints
                                             where wp.Id == f.TermitationPointId
                                             select wp).FirstOrDefault(),
                     };


        }
    }
}
