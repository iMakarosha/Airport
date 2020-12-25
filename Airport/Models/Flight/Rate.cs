using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airport.Models.AircraftFleet;
using Airport.Models.Worker;

namespace Airport.Models.Flight
{
    public class Rate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public bool Cancellble { get; set; }
        [Required]
        public bool Returnable { get; set; }
        [Required]
        public string BaggageDimensions { get; set; }
        [Required]
        public ServiceClass ServiceClass { get; set; }
    }
}
