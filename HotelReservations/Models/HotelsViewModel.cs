using HotelReservations.Data.Model;
using HotelReservations.Web.Areas.HotelAdministration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservations.Web.Models
{
    public class HotelsViewModel
    {
        //public HotelsViewModel()
        //{
        //    this.Collection = new List<HotelsViewModel>();
        //}


        public ICollection<HotelViewModel> Collection { get; set; }
    }
}