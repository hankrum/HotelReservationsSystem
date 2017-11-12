using HotelReservations.Data.Model;
using HotelReservations.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservations.Web.Models
{
    public class ReservationViewModel
    {
        public ReservationViewModel()
        {
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }

        public Guid HotelId { get; set; }

        public string UserId { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        //TODO: Validation
        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Required]
        //TODO: Minvalue = 1
        public short AdultsNumber { get; set; }

        public short ChildrenNumber { get; set; }

        [Required]
        public string MealPlan { get; set; }

        //public virtual Room Room { get; set; }

        public Reservation CreateReservation ()
        {
            Reservation result = new Reservation();

            result.StartDate = (DateTime)this.StartDate;
            result.EndDate = (DateTime)this.EndDate;
            result.AdultsNumber = this.AdultsNumber;
            result.ChildrenNumber = this.ChildrenNumber;
            result.MealPlan = (MealPlan) Enum.Parse(typeof(MealPlan), this.MealPlan);

            result.User = new User();
            result.User.Id = this.UserId;
            result.Hotel = new Hotel();
            result.Hotel.Id = this.HotelId;

            return result;
        }
    }
}