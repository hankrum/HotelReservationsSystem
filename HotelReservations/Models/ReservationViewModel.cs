using HotelReservations.Data.Model;
using HotelReservations.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Web.Models
{
    public class ReservationViewModel
    {
        public Guid HotelId { get; set; }

        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public short AdultsNumber { get; set; }

        public short ChildrenNumber { get; set; }

        public MealPlan MealPlan { get; set; }

        public virtual Room Room { get; set; }
    }
}