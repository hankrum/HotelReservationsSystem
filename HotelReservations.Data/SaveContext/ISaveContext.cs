﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.SaveContext
{
    public interface ISaveContext
    {
        void Commit();
    }
}
