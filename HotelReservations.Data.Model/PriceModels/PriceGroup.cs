using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.PriceModels
{
    public class PriceGroup : DataModel
    {
        public PriceSet PerRoom { get; set; }

        public PriceSet PerMainBed { get; set; }

        public PriceSet PerAdditionalBed { get; set; }

        public PriceSet PerChildBed { get; set; }

        //[ForeignKey("RoomType")]
        public virtual RoomType RoomType { get; set; }
    }
}
