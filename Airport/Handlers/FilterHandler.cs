using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.ViewModels;
namespace Airport.Handlers
{
    public class FilterHandler
    {
        public bool IsEmptyFilter(FilterMain filter)
        {
            if (string.IsNullOrEmpty(filter.StartingPoint) || string.IsNullOrEmpty(filter.TermitationPoint) || filter.ServiceClass == null || filter.Date == new DateTime())
            {
                return true;
            }
            return false;
        }
        public bool IsEmptyFilter(FilterCustom filter)
        {
            if (filter.MaxCost == 0 && filter.MinCost == 0 && filter.AircraftModelId == 0 && filter.AirlineId == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsEmptyFilter(FlightFilter filter)
        {
            if (string.IsNullOrEmpty(filter.StartingPoint) && string.IsNullOrEmpty(filter.TermitationPoint) && filter.Date == new DateTime())
            {
                return true;
            }
            return false;
        }
        public bool IsEmptyFilter(PassengerFilter filter)
        {
            if (string.IsNullOrEmpty(filter.Name) && string.IsNullOrEmpty(filter.Surname) && string.IsNullOrEmpty(filter.DocumentValue) && string.IsNullOrEmpty(filter.Email))
            {
                return true;
            }
            return false;
        }
        public bool IsEmptyFilter(TicketFilter filter)
        {
            if (filter.TicketId == 0 && string.IsNullOrEmpty(filter.PassengerSurname) && string.IsNullOrEmpty(filter.PassengerDocumentValue) && filter.Date == new DateTime())
            {
                return true;
            }
            return false;
        }
    }
}
