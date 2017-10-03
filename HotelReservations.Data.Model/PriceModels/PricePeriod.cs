using HotelReservations.Data.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.PriceModels
{
    public class PricePeriod : DataModel
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public int? WeekendPercent { get; set; }

        [Required]
        [ForeignKey("PriceGroup")]
        public virtual Guid PriceGroupId { get; set; }

        public virtual PriceGroup PriceGroup { get; set; }
    }
}
