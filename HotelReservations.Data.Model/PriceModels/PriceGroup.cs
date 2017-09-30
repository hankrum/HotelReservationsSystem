﻿using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.PriceModels
{
    public class PriceGroup : DataModel
    {
        PriceSet PerRoom { get; set; }

        PriceSet PerMainBed { get; set; }

        PriceSet PerAdditionalBed { get; set; }

        PriceSet PerChildBed { get; set; }

        Guid RoomTypeId { get; set; }
    }
}