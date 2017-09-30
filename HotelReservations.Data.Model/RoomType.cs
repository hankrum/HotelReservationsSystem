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
        public short MainBeds { get; set; }

        [Required]
        public short AdditionalBeds { get; set; }

        public bool HasBathTube { get; set; }

        public bool HasTV { get; set; }

        public bool HasTerrace { get; set; }

        public bool HasAirConditioner { get; set; }

        public bool HasRefrigerator { get; set; }

        public bool HasHairDryer { get; set; }

        public virtual HashSet<PricePeriod> PeriodPriceLists { get; set; }
    }
}
