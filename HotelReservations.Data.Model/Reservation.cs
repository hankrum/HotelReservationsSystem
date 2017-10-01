using HotelReservations.Data.Model.Abstractions;
using HotelReservations.Infrastructure.Enums;
using System;

namespace HotelReservations.Data.Model
{
    public class Reservation : DataModel
    {
        public virtual Hotel Hotel { get; set; }

        public virtual User User { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        short AdultsNumber { get; set; }

        short ChildrenNumber { get; set; }

        MealPlan MealPlan { get; set; }

        Room Room { get; set; }
    }
}
