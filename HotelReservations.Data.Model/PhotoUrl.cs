using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model
{
    public class PhotoUrl : DataModel
    {
        public string Url { get; set; }

        //public virtual Hotel Hotel { get; set; }
    }
}
