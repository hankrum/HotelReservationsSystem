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
        Guid TypeId { get; set; }

        //[ForeignKey("Hotel")]
        Guid HotelId { get; set; }
    }
}
