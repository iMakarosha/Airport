using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Data;
using Airport.Models;
using Airport.ViewModels;
using Airport.Models.AircraftFleet;
using Airport.Models.Flight;
using Airport.Handlers;
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

        public List<ServiceClassesFilter> GetServiceClasses()
        {
            var result = new List<ServiceClassesFilter>();
            foreach (var item in Enum.GetValues(typeof(ServiceClass)))
            {
                result.Add(new ServiceClassesFilter
                {
                    ServiceClassValue = Convert.ToInt32(item),
                    ServiceClassName = EnumExtensions.GetDisplayName((ServiceClass)item)
                });
            }

            return result;
        }

        public IEnumerable<FlightByRate> GetSearchViewModel(FilterMain filter, FilterCustom filterCustom)
        {
            try
            {
                //List<ServiceClass> serviceClasses = new List<ServiceClass>();
                //foreach (var item in filter.ServiceClass) {
                //    serviceClasses.Add(EnumExtensions.GetEnumObjectByValue<ServiceClass>(item.ServiceClassValue));
                //}

                var result = (from f in db.Flights
                              join fr in db.Flight_Rates on f.Id equals fr.FlightId
                              join r in db.Rates on fr.RateId equals r.Id
                              join a in db.Aircrafts on f.AircraftId equals a.Id
                              join am in db.AircraftModels on a.ModelId equals am.Id
                              join airl in db.Airlines on f.AirlineId equals airl.Id
                              join wp1 in db.Waypoints on f.StartingPointId equals wp1.Id
                              join wp2 in db.Waypoints on f.TermitationPointId equals wp2.Id
                              //where serviceClasses.Contains(r.ServiceClass) &
                              where filter.ServiceClass.Contains(r.ServiceClass) &
                                    EF.Functions.Like(f.StartingPoint.City, "%" + filter.StartingPoint + "%") &
                                    EF.Functions.Like(f.TermitationPoint.City, "%" + filter.TermitationPoint + "%") &
                                    f.StartingPoint.DateTime.Date == filter.Date

                              select new FlightByRate
                              {
                                  FlightId = f.Id,
                                  RateId = r.Id,
                                  Aircraft = a,
                                  AirlineId = airl.Id,
                                  AirlineName = airl.Name,
                                  Name = r.Name,
                                  Cost = r.Cost,
                                  BaggageDimensions = r.BaggageDimensions,
                                  Cancellble = r.Cancellble,
                                  Returnable = r.Returnable,
                                  ServiceClass = r.ServiceClass,
                                  StartingPoint = wp1,
                                  TermitationPoint = wp2,
                                  LeftPlaces = (from sc in db.Salon_ServiceClasses
                                                where a.Id == f.AircraftId
                                                select sc.CountSeating).First()
                                               -
                                               (from t in db.Tickets
                                                where t.Rate.ServiceClass == r.ServiceClass
                                                select t.Id).Count()
                              });

                if (!new FilterHandler().IsEmptyFilter(filterCustom))
                {
                    result = result.Where(a => a.AirlineId == filterCustom.AirlineId);
                }

                return result.ToList();
               
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
