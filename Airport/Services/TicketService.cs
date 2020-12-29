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
    public class TicketService : Controller
    {
        ApplicationDbContext db;

        public TicketService(ApplicationDbContext context)
        {
            db = context;
        }
        
        public AddTicketViewModel GetTicketViewModel(int flightId, int rateId)
        {
            AddTicketViewModel result = new AddTicketViewModel();
            result.FlightId = flightId;
            result.RateId = rateId;
            result.Ages = EnumExtensions.GetEnumList("Age");
            result.Genders = EnumExtensions.GetEnumList("Gender");
            result.Documents = EnumExtensions.GetEnumList("Document");

            result.TicketInfo = (from f in db.Flights
                                 join fr in db.Flight_Rates on f.Id equals fr.FlightId
                                 join r in db.Rates on fr.RateId equals r.Id
                                 join a in db.Aircrafts on f.AircraftId equals a.Id
                                 join am in db.AircraftModels on a.ModelId equals am.Id
                                 join airl in db.Airlines on f.AirlineId equals airl.Id
                                 join wp1 in db.Waypoints on f.StartingPointId equals wp1.Id
                                 join wp2 in db.Waypoints on f.TermitationPointId equals wp2.Id
                                 where f.Id == flightId & r.Id == rateId
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
                                 }).First();
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
        public string AddNewTicket(NewTicket ticketInfo)
        {
            try
            {
                DateTime ticketDateTime = DateTime.Now.Date;
                string cashierId = db.Users.Where(u => u.Email == ticketInfo.CashierName).Select(u => u.Id).First();
                ticketInfo.Document.Value = ticketInfo.Document.Value.Replace(" ", "");
                var documentType = EnumExtensions.GetEnumObjectByValue<DocumentType>(ticketInfo.Document.Type);
                int passengerId = -1;
                Passenger passenger = (from p in db.Passengers
                                   join dc in db.Document on p.Id equals dc.PassengerId
                                   where dc.DocumentType == documentType &
                                        dc.Value == ticketInfo.Document.Value
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

                if (passenger != null)
                {
                    passengerId = passenger.Id;
                    passenger.Age = ticketInfo.Passenger.Age;
                    passenger.Birthday = ticketInfo.Passenger.Birthday;
                    passenger.Citizenship = ticketInfo.Passenger.Citizenship;
                    passenger.Email = ticketInfo.Passenger.Email;
                    passenger.Phone = ticketInfo.Passenger.Phone;
                    passenger.Gender = ticketInfo.Passenger.Gender;
                    passenger.Name = ticketInfo.Passenger.Name;
                    passenger.Patronumic = ticketInfo.Passenger.Patronumic;
                    passenger.Surname = ticketInfo.Passenger.Surname;
                    if (!String.IsNullOrEmpty(ticketInfo.Passenger.Phone))
                    {
                        passenger.Phone = ticketInfo.Passenger.Phone;
                    }
                    if (!String.IsNullOrEmpty(ticketInfo.Passenger.Notes))
                    {
                        passenger.Notes = ticketInfo.Passenger.Notes;
                    }
                    db.Passengers.Update(passenger);

                    Document document = db.Document.Where(dc => dc.PassengerId == passenger.Id && dc.DocumentType == documentType).FirstOrDefault();
                    if(document != null)
                    {
                        document.Value = ticketInfo.Document.Value;
                        db.Document.Update(document);
                    }
                    else
                    {
                        db.Document.Add(new Document
                        {
                            PassengerId = passengerId,
                            DocumentType = documentType,
                            Value = ticketInfo.Document.Value
                        });
                    }
                    db.SaveChanges();
                }
                else
                {
                    db.Passengers.Add(ticketInfo.Passenger);
                    db.SaveChanges();
                    passengerId = ticketInfo.Passenger.Id;
                    db.Document.Add(new Document
                    {
                        PassengerId = passengerId,
                        DocumentType = documentType,
                        Value = ticketInfo.Document.Value
                    });
                    db.SaveChanges();
                }
                Ticket newTicket = new Ticket
                {
                    CashierId = cashierId,
                    DateTime = DateTime.Now,
                    FlightId = ticketInfo.FlightId,
                    PassengerId = passengerId,
                    RateId = ticketInfo.RateId
                };
                db.Tickets.Add(newTicket);

                db.SaveChanges();
                return "Ok," + newTicket.Id.ToString() + "," + ticketInfo.Passenger.Email;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateTicket(int ticketId)
        {
            try
            {
                Ticket updatedTicket = db.Tickets.Where(t => t.Id == ticketId).Select(t => t).First();
                updatedTicket.PaymentInfo = "Номер карты: **** " + (""+updatedTicket.Id + updatedTicket.PassengerId + updatedTicket.RateId + updatedTicket.Id).ToString().Substring(0, 4);
                db.Tickets.Update(updatedTicket);
                db.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string TryRemoveTicket(int ticketId, bool triggerRemove)
        {
            try
            {
                Ticket ticket = db.Tickets.Where(t => t.Id == ticketId).Select(t => t).First();

                if ((String.IsNullOrEmpty(ticket.PaymentInfo) && triggerRemove) || !triggerRemove)
                {
                    string passengerEmail = db.Passengers.Where(p=>p.Id == ticket.PassengerId).Select(p=>p.Email).First();
                    db.Tickets.Remove(ticket);
                    db.SaveChanges();
                    return "Ok," + passengerEmail;
                }
                else {
                    return null;
                }

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
