using HotelReservations.Data.Model.Abstractions;
using HotelReservations.Data.Model.PriceModels;
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

        [Required]
        short MainBeds { get; set; }

        [Required]
        short AdditionalBeds { get; set; }

        bool HasBathTube { get; set; }

        bool HasTV { get; set; }

        bool HasTerrace { get; set; }

        bool HasAirConditioner { get; set; }

        bool HasRefrigerator { get; set; }

        bool HasHairDryer { get; set; }

        HashSet<PriceGroup> PriceGroups { get; set; }
    }
}
