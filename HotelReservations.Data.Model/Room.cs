using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model
{
    public class Room : NamedModel
    {
        //public virtual Guid TypeId { get; set; }

        //[ForeignKey("RoomType")]
        public virtual RoomType RoomType { get; set; }

        //[ForeignKey("Hotel")]
        public virtual Hotel Hotel { get; set; }
    }
}
