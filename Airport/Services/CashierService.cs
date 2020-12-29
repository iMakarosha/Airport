using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Data;
using Airport.Models;
using Airport.ViewModels;
using Airport.Models.AircraftFleet;
using Airport.Models.Flight;
using Airport.Models.Customer;
using Airport.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airport.Services
{
    public class CashierService : Controller
    {
        ApplicationDbContext db;

        public CashierService(ApplicationDbContext context)
        {
            db = context;
        }

        public List<FlightByFilter> GetFlightsByFilter(FlightFilter filter = null)
        {
            try
            {
                var result = (from f in db.Flights
                              join a in db.Aircrafts on f.AircraftId equals a.Id
                              join am in db.AircraftModels on a.ModelId equals am.Id
                              join airl in db.Airlines on f.AirlineId equals airl.Id
                              join wp1 in db.Waypoints on f.StartingPointId equals wp1.Id
                              join wp2 in db.Waypoints on f.TermitationPointId equals wp2.Id

                              select new FlightByFilter
                              {
                                  FlightId = f.Id,
                                  Aircraft = a,
                                  AircraftModel = am.Model,
                                  AirlineId = airl.Id,
                                  AirlineName = airl.Name,
                                  StartingPoint = wp1,
                                  TermitationPoint = wp2
                              });

                if(filter != null)
                {
                    if (!new FilterHandler().IsEmptyFilter(filter))
                    {
                        if (!String.IsNullOrEmpty(filter.StartingPoint))
                        {
                            result = result.Where(f => f.StartingPoint.City.Contains(filter.StartingPoint));
                        }
                        if (!String.IsNullOrEmpty(filter.TermitationPoint))
                        {
                            result = result.Where(f => f.TermitationPoint.City.Contains(filter.TermitationPoint));
                        }
                        if (!(filter.Date == new DateTime()))
                        {
                            result = result.Where(f => f.StartingPoint.DateTime.Date == filter.Date);
                        }
                    }
                }

                return result.OrderBy(r=>r.StartingPoint.DateTime).ToList();
               
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<Passenger> GetPassengersByFilter(PassengerFilter filter = null)
        {
            try
            {
                var result = (from p in db.Passengers 
                              select new  Models.Customer.Passenger
                                  {
                                      Id = p.Id,
                                      Age = p.Age,
                                      Birthday = p.Birthday,
                                      Documents = (from d in db.Document
                                                   where d.PassengerId == p.Id
                                                   select new Document
                                                   {
                                                       Id = d.Id,
                                                       DocumentType = d.DocumentType,
                                                       Value = d.Value
                                                   }).ToList(),
                                      BonusCardId = p.BonusCardId,
                                      Citizenship = p.Citizenship,
                                      Email = p.Email,
                                      Gender = p.Gender,
                                      Name = p.Name,
                                      Notes = p.Notes,
                                      PasswordHash = p.PasswordHash,
                                      Patronumic = p.Patronumic,
                                      Phone = p.Phone,
                                      Surname = p.Surname
                                  });

                if (filter != null)
                {
                    if (!new FilterHandler().IsEmptyFilter(filter))
                    {
                        if (!String.IsNullOrEmpty(filter.Name))
                        {
                            result = result.Where(f => f.Name.Contains(filter.Name));
                        }
                        if (!String.IsNullOrEmpty(filter.Surname))
                        {
                            result = result.Where(f => f.Surname.Contains(filter.Surname));
                        }
                        if (!String.IsNullOrEmpty(filter.Email))
                        {
                            result = result.Where(f => f.Email.Contains(filter.Email));
                        }
                    }
                }
                var listResult = result.OrderBy(p => p.Id).ToList();
                if (filter != null)
                {
                    if (!new FilterHandler().IsEmptyFilter(filter))
                    {
                        if (!String.IsNullOrEmpty(filter.DocumentValue))
                        {
                            listResult = listResult.FindAll(f => f.Documents.Exists(doc => doc.Value.Contains(filter.DocumentValue)));
                        }
                    }
                }
                return listResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TicketFull> GetTicketsByFilter(TicketFilter filter = null)
        {
            try
            {
                var result = (from t in db.Tickets
                              join p in db.Passengers on t.PassengerId equals p.Id
                              join u in db.Users on t.CashierId equals u.Id
                              join r in db.Rates on t.RateId equals r.Id
                              join fr in db.Flight_Rates on r.Id equals fr.RateId
                              join f in db.Flights on fr.FlightId equals f.Id

                              select new TicketFull
                              {
                                  Id = t.Id,
                                  Date = t.DateTime,
                                  Passenger = new Models.Customer.Passenger
                                  {
                                      Id = p.Id,
                                      Age = p.Age,
                                      Birthday = p.Birthday,
                                      Documents = (from d in db.Document
                                                   where d.PassengerId == p.Id
                                                   select new Models.Customer.Document
                                                   {
                                                       Id = d.Id,
                                                       DocumentType = d.DocumentType,
                                                       Value = d.Value
                                                   }).ToList(),
                                      BonusCardId = p.BonusCardId,
                                      Citizenship = p.Citizenship,
                                      Email = p.Email,
                                      Gender = p.Gender,
                                      Name = p.Name,
                                      Notes = p.Notes,
                                      PasswordHash = p.PasswordHash,
                                      Patronumic = p.Patronumic,
                                      Phone = p.Phone,
                                      Surname = p.Surname
                                  },
                                  Flight = f,
                                  Rate = r,
                                  CashierName = u.Email,
                                  PaymentInfo = t.PaymentInfo
                              });

                if (filter != null)
                {
                    if (!new FilterHandler().IsEmptyFilter(filter))
                    {
                        if (filter.TicketId > 0)
                        {
                            result = result.Where(t => t.Id == filter.TicketId);
                        }
                        if (!(filter.Date == new DateTime()))
                        {
                            result = result.Where(t => t.Date == filter.Date);
                        }
                        if (!String.IsNullOrEmpty(filter.PassengerSurname))
                        {
                            result = result.Where(p => p.Passenger.Surname.Contains(filter.PassengerSurname));
                        }
                    }
                }

                var listResult = result.OrderByDescending(p => p.PaymentInfo).ToList();
                if (filter != null)
                {
                    if (!new FilterHandler().IsEmptyFilter(filter))
                    {
                        if (!String.IsNullOrEmpty(filter.PassengerDocumentValue))
                        {
                            listResult = listResult.FindAll(p => p.Passenger.Documents.Exists(doc => doc.Value.Contains(filter.PassengerDocumentValue)));
                        }
                    }
                }
                return listResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FlightFullInfo GetFlightsItem(int flightId)
        {
            try
            {
                var result = new FlightFullInfo();
                result.Flight = (from f in db.Flights
                              join fr in db.Flight_Rates on f.Id equals fr.FlightId
                              join r in db.Rates on fr.RateId equals r.Id
                              join a in db.Aircrafts on f.AircraftId equals a.Id
                              join am in db.AircraftModels on a.ModelId equals am.Id
                              join airl in db.Airlines on f.AirlineId equals airl.Id
                              join wp1 in db.Waypoints on f.StartingPointId equals wp1.Id
                              join wp2 in db.Waypoints on f.TermitationPointId equals wp2.Id
                              where f.Id == flightId

                              select new FlightByFilter
                              {
                                  FlightId = f.Id,
                                  RateId = r.Id,
                                  Aircraft = a,
                                  AircraftModel = am.Model,
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
                              }).FirstOrDefault();

                result.Tickets = (from t in db.Tickets
                               join p in db.Passengers on t.PassengerId equals p.Id
                               join u in db.Users on t.CashierId equals u.Id
                               join r in db.Rates on t.RateId equals r.Id
                               join fr in db.Flight_Rates on r.Id equals fr.RateId
                               join f in db.Flights on fr.FlightId equals f.Id
                               join d in db.Document on p.Id equals d.PassengerId
                               where f.Id == flightId

                               select new TicketFull
                               { 
                                   Id = t.Id,
                                   Date = t.DateTime,
                                   Passenger = new Models.Customer.Passenger
                                   {
                                       Id = p.Id,
                                       Age = p.Age,
                                       Birthday = p.Birthday,
                                       Documents = (from d in db.Document
                                                   where d.PassengerId == p.Id
                                                   select new Models.Customer.Document
                                                   {
                                                       Id = d.Id,
                                                       DocumentType = d.DocumentType,
                                                       Value = d.Value
                                                   }).ToList(),
                                       BonusCardId = p.BonusCardId,
                                       Citizenship = p.Citizenship,
                                       Email = p.Email,
                                       Gender = p.Gender,
                                       Name = p.Name,
                                       Notes = p.Notes,
                                       PasswordHash = p.PasswordHash,
                                       Patronumic = p.Patronumic,
                                       Phone = p.Phone,
                                       Surname = p.Surname
                                   },
                                   Flight = f,
                                   Rate = r,
                                   CashierName = u.Email,
                                   PaymentInfo = t.PaymentInfo 
                               }).ToList();
                result.Rates = (from f in db.Flights
                                join fr in db.Flight_Rates on f.Id equals fr.FlightId
                                join r in db.Rates on fr.RateId equals r.Id
                                where fr.FlightId == flightId
                                select new Rate
                                {
                                    Id = r.Id,
                                    Name = r.Name,
                                    Cost = r.Cost,
                                    BaggageDimensions = r.BaggageDimensions,
                                    Cancellble = r.Cancellble,
                                    Returnable = r.Returnable,
                                    ServiceClass = r.ServiceClass
                                }).ToList();

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PassengerFullInfo GetPassengersItem(int passengerId)
        {
            try
            {
                var result = new PassengerFullInfo();
                result.PassengerId = passengerId;
                result.Ages = EnumExtensions.GetEnumList("Age");
                result.Genders = EnumExtensions.GetEnumList("Gender");
                result.Documents = EnumExtensions.GetEnumList("Document");
                result.Passenger = (from p in db.Passengers
                                    where p.Id == passengerId
                                    select new Models.Customer.Passenger
                                    {
                                        Id = p.Id,
                                        Age = p.Age,
                                        Birthday = p.Birthday,
                                        Documents = (from d in db.Document
                                                     where d.PassengerId == p.Id
                                                     select new Document
                                                     {
                                                         Id = d.Id,
                                                         DocumentType = d.DocumentType,
                                                         Value = d.Value
                                                     }).ToList(),
                                        BonusCardId = p.BonusCardId,
                                        Citizenship = p.Citizenship,
                                        Email = p.Email,
                                        Gender = p.Gender,
                                        Name = p.Name,
                                        Notes = p.Notes,
                                        PasswordHash = p.PasswordHash,
                                        Patronumic = p.Patronumic,
                                        Phone = p.Phone,
                                        Surname = p.Surname
                                    }).First() ;
                result.Document = new TicketDocument
                {
                    Type = Convert.ToInt32(result.Passenger.Documents[0].DocumentType),
                    Value = result.Passenger.Documents[0].Value
                };

                result.Tickets = (from t in db.Tickets
                                  join u in db.Users on t.CashierId equals u.Id
                                  join r in db.Rates on t.RateId equals r.Id
                                  join fr in db.Flight_Rates on r.Id equals fr.RateId
                                  join f in db.Flights on fr.FlightId equals f.Id
                                  where t.PassengerId == passengerId

                                  select new TicketFull
                                  {
                                      Id = t.Id,
                                      Date = t.DateTime,
                                      Flight = f,
                                      Rate = r,
                                      CashierName = u.Email,
                                      PaymentInfo = t.PaymentInfo
                                  }).ToList();

             return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TicketFullInfo GetTicketsItem(int ticketId)
        {
            try
            {
                var result = new TicketFullInfo();
                result.Ages = EnumExtensions.GetEnumList("Age");
                result.Genders = EnumExtensions.GetEnumList("Gender");
                result.Documents = EnumExtensions.GetEnumList("Document");


                result.Ticket = (from t in db.Tickets
                                 join u in db.Users on t.CashierId equals u.Id
                                 join r in db.Rates on t.RateId equals r.Id
                                 join fr in db.Flight_Rates on r.Id equals fr.RateId
                                 join f in db.Flights on fr.FlightId equals f.Id
                                 where t.Id == ticketId
                                 select new TicketFull
                                 {
                                     Id = t.Id,
                                     Date = t.DateTime,
                                     Flight = f,
                                     Rate = r,
                                     CashierName = u.Email,
                                     PaymentInfo = t.PaymentInfo,
                                     Passenger = new Passenger
                                     {
                                         Id = t.PassengerId
                                     },
                                     PdfFilePath = t.PdfFilePath
                                 }).First();

                result.Passenger = (from p in db.Passengers
                                    where p.Id == result.Ticket.Passenger.Id
                                    select new Models.Customer.Passenger
                                    {
                                        Id = p.Id,
                                        Age = p.Age,
                                        Birthday = p.Birthday,
                                        Documents = (from d in db.Document
                                                     where d.PassengerId == p.Id
                                                     select new Document
                                                     {
                                                         Id = d.Id,
                                                         DocumentType = d.DocumentType,
                                                         Value = d.Value
                                                     }).ToList(),
                                        BonusCardId = p.BonusCardId,
                                        Citizenship = p.Citizenship,
                                        Email = p.Email,
                                        Gender = p.Gender,
                                        Name = p.Name,
                                        Notes = p.Notes,
                                        PasswordHash = p.PasswordHash,
                                        Patronumic = p.Patronumic,
                                        Phone = p.Phone,
                                        Surname = p.Surname
                                    }).First();
                result.Document = new TicketDocument
                {
                    Type = Convert.ToInt32(result.Passenger.Documents[0].DocumentType),
                    Value = result.Passenger.Documents[0].Value
                };

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string SavePassenger(UpdatePassenger changedPass)
        {
            try
            {
                var documentType = EnumExtensions.GetEnumObjectByValue<DocumentType>(changedPass.Document.Type);
                Passenger passengerChanged = (from p in db.Passengers
                                       where p.Id == changedPass.PassengerId
                                       select new Passenger
                                       {
                                           Id = p.Id,
                                           Age = p.Age,
                                           Birthday = p.Birthday,
                                           Documents = p.Documents,
                                           BonusCardId = p.BonusCardId,
                                           Citizenship = p.Citizenship,
                                           Email = p.Email,
                                           Gender = p.Gender,
                                           Name = p.Name,
                                           Notes = p.Notes,
                                           PasswordHash = p.PasswordHash,
                                           Patronumic = p.Patronumic,
                                           Phone = p.Phone,
                                           Surname = p.Surname
                                       }).FirstOrDefault();

                    passengerChanged.Age = changedPass.Passenger.Age;
                    passengerChanged.Birthday = changedPass.Passenger.Birthday;
                    passengerChanged.Citizenship = changedPass.Passenger.Citizenship;
                    passengerChanged.Email = changedPass.Passenger.Email;
                    passengerChanged.Phone = changedPass.Passenger.Phone;
                    passengerChanged.Gender = changedPass.Passenger.Gender;
                    passengerChanged.Name = changedPass.Passenger.Name;
                    passengerChanged.Patronumic = changedPass.Passenger.Patronumic;
                    passengerChanged.Surname = changedPass.Passenger.Surname;
                    if (!String.IsNullOrEmpty(changedPass.Passenger.Phone))
                    {
                    passengerChanged.Phone = changedPass.Passenger.Phone;
                    }
                    if (!String.IsNullOrEmpty(changedPass.Passenger.Notes))
                    {
                    passengerChanged.Notes = changedPass.Passenger.Notes;
                    }
                    db.Passengers.Update(passengerChanged);
                    db.SaveChanges();

                    Document document = db.Document.Where(dc => dc.PassengerId == passengerChanged.Id && dc.DocumentType == documentType).FirstOrDefault();
                    if (document != null)
                    {
                        document.Value = changedPass.Document.Value;
                        db.Document.Update(document);
                    }
                    else
                    {
                        db.Document.Remove(db.Document.Where(d => d.PassengerId == passengerChanged.Id).Select(d => d).FirstOrDefault());
                        db.Document.Add(new Document
                        {
                            PassengerId = changedPass.PassengerId,
                            DocumentType = documentType,
                            Value = changedPass.Document.Value
                        });
                    }
                    db.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
