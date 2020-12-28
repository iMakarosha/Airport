using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Models.Customer
{
    public class Passenger
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
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public string Citizenship { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Age Age { get; set; }
        public string PasswordHash { get; set; }
        public string Notes { get; set; }

        public int? BonusCardId { get; set; }
        public BonusCard BonusCard { get; set; }

        //public int DocumentId { get; set; }
        public List<Document> Documents { get; set; }
    }

    public class Document
    {
        public int Id { get; set; }
        [Required]
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        [Required]
        [MaxLength(30)]
        public DocumentType DocumentType { get; set; }
        [Required]
        [MaxLength(20)]
        public string Value { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Мужской")]
        m,
        [Display(Name = "Женский")]
        f
    }

    public enum Age
    {
        [Display(Name = "Взрослый")]
        a,
        [Display(Name = "Ребенок")]
        c,
        [Display(Name = "Младенец")]
        b
    }

    public enum DocumentType
    {
        [Display(Name = "Паспорт")]
        passport,
        [Display(Name = "Загранпаспорт")]
        international_passport,
        [Display(Name = "Свидетельство о рождении")]
        birth_certificate,
        [Display(Name = "Виза")]
        visa,
        [Display(Name = "Военный билет")]
        millitaryId
    }
}
