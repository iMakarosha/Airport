using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Models.Worker
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        [MaxLength(100)]
        public string Patronumic { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Phone { get; set; }
        [Required]
        public DateTime EmploymentDate { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }

        [Required]
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }

    public class Pilot : Employee
    {
        public List<Models.Flight.Flight> Flights { get; set; }
    }

    public class Position
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string PositionName { get; set; }
    }
}
