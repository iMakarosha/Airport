using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Models.AircraftFleet
{
    public class Aircraft
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string TailNumber { get; set; }
        [Required]
        public int ModelId { get; set; }
        public AircraftModel Model { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CommissioningYear { get; set; }
        [Required]
        public int Lifetime { get; set; }
        [Required]
        public Readiness Readiness { get; set; }
        public string SeatingDiagram { get; set; }
        public string DistanceBetweenSeats { get; set; }
        public List<Salon_ServiceClass> ServiceClasses { get; set; }
    }

    public class AircraftModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Model { get; set; }
    }

    public enum Readiness
    {
        [Display(Name = "Готов")]
        ready,
        [Display(Name = "На диагностике")]
        diagnostic,
        [Display(Name = "В ремонте")]
        repair,
        [Display(Name = "Неисправен")]
        incapacitated
    }
}
