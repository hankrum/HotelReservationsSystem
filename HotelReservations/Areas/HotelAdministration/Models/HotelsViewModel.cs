using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Web.Areas.HotelAdministration.Models
{
    public class HotelsOfUserViewModel
    {
        public IEnumerable<HotelViewModel> Hotels { get; set; }
    }
}