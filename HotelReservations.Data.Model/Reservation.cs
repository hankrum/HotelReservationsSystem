using HotelReservations.Data.Model.Abstractions;
using HotelReservations.Infrastructure.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservations.Data.Model
{
    public class Reservation : DataModel
    {
        //[ForeignKey("Hotel")]
        public virtual Hotel Hotel { get; set; }

        //[ForeignKey("User")]
        public virtual User User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public short AdultsNumber { get; set; }

        public short ChildrenNumber { get; set; }

        //[ForeignKey("MealPlan")]
        public MealPlan MealPlan { get; set; }

        //[ForeignKey("Room")]
        public virtual Room Room { get; set; }
    }
}
