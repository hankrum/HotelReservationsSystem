﻿using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.PriceModels
{
    public class PricePeriod : DataModel
    {
        DateTime Start { get; set; }

        DateTime End { get; set; }

        int WeekendPercent { get; set; }

        PriceGroup Price { get; set; }
    }
}