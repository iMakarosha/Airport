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
    public class Waypoint
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        [Required]
        [MaxLength(80)]
        public string City { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [MaxLength(80)]
        public string Airport { get; set; }
        [Required]
        public int Terminal { get; set; }
        public string Notes { get; set; }
    }
}
