using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.PriceModels
{
    public class PricePeriod
    {
        DateTime Start { get; set; }

        DateTime End { get; set; }

        int WeekendPercent { get; set; }

        PriceGroup Price { get; set; }
    }
}
