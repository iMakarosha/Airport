using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Models.AircraftFleet
{
    public class Salon
    {
        public int Id { get; set; }
        [Required]
        public int AircraftId { get; set; }
        [Required]
        public string SeatingDiagram { get; set; }
        [Required]
        public string DistanceBetweenSeats { get; set; }
        public List<Salon_ServiceClass> ServiceClasses { get; set; }
    }

    public class Salon_ServiceClass
    {
        public int Id { get; set; }
        [Required]
        public int SalonId { get; set; }
        [Required]
        public ServiceClass ServiceClass { get; set; }
        [Required]
        public int CountSeating { get; set; }
    }

    public enum ServiceClass
    {
        [Display(Name = "Эконом")]
        e = 0,
        [Display(Name = "Бизнес")]
        b = 1,
        [Display(Name = "Первый")]
        f = 2
    }

}
