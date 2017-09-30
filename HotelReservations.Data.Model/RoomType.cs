using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model
{
    public class RoomType : DataModel
    {
        [Required]
        string Name { get; set; }

        short MainBeds { get; set; }

        short AdditionalBeds { get; set; }

        bool HasBathTube { get; set; }

        bool HasTV { get; set; }

        bool HasTerrace { get; set; }

        bool HasAirConditioner { get; set; }

        bool HasRefrigerator { get; set; }

        bool HasHairDrier { get; set; }

        Guid PriceGroupId { get; set; }
    }
}
