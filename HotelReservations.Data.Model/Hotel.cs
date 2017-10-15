using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model
{
    public class Hotel : DataModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Index]
        [Range(1, 5)]
        public short Stars { get; set; }

        public string Address { get; set; }

        //[ForeignKey("City")]
        [Required]
        [Index]
        public virtual City City { get; set; }

        public string Zip { get; set; }

        //[ForeignKey("Country")]
        [Required]
        [Index]
        public virtual Country Country { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual HashSet<Room> Rooms {get; set; }

        public virtual HashSet<PhotoUrl> PhotoUrls { get; set; }

        public string FirstPhotoUrl { get; set; }

        public bool HasParking { get; set; }

        public bool HasRestaurant { get; set; }

        public bool HasInternet { get; set; }
    }
}
