using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.PriceModels
{
    public class PriceSet
    {
        double? BedOnly { get; set; }

        double? BB { get; set; }

        double? HB { get; set; }

        double? FB { get; set; }

        double? AllInclusive { get; set; }
    }
}
