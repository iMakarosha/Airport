using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Airport.Models.Customer
{
    public class BonusCard
    {
        public int Id { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public int BonusPersent { get; set; }
    }
}
