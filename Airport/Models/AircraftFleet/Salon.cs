using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Models.AircraftFleet
{
    public class Salon_ServiceClass
    {
        public int Id { get; set; }
        public int? AircraftId { get; set; }
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
