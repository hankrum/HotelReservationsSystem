﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Web.Areas.SiteAdministration.Models
{
    public class HotelAdminsViewModel
    {
        ICollection<HotelAdminViewModel> HotelAdmins { get; set; }
    }
}