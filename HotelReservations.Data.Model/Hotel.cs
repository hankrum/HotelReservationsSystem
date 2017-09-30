using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model
{
    public class Hotel : DataModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        [ForeignKey("City")]
        public virtual City City { get; set; }

        public string Zip { get; set; }

        [ForeignKey("Country")]
        public virtual Country Country { get; set; }

        public virtual HashSet<Room> Rooms {get; set; }
    }
}
