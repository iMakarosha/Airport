using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Data;
using Airport.Models;

namespace Airport
{
    public static class SampleData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //if (!context.BonusCards.Any())
            //{
            //    context.BonusCards.AddRange(
            //        new Models.Customer.BonusCard
            //        {
            //            BonusPersent = 5,
            //            Balance = 100
            //        },
            //         new Models.Customer.BonusCard
            //         {
            //         }); 
            //}
            //if (!context.Passengers.Any())
            //{
            //    context.Passengers.AddRange(
            //        new Models.Customer.Passenger
            //        {
            //            Surname = "Иванов",
            //            Name = "Евгений",
            //            Patronumic = "Сергеевич",
            //            Email = "john@gmail.ru",
            //            Phone = "79075486534",
            //            Gender = 'm',
            //            Age = 'a',
            //            Birthday = DateTime.Today,
            //            Citizenship = "Россия"
            //        });
            //}
            context.SaveChanges();
        }
    }
}
