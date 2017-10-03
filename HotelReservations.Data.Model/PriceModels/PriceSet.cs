using HotelReservations.Data.Model.Abstractions;

namespace HotelReservations.Data.Model.PriceModels
{
    public class PriceSet : DataModel
    {
        public double? BedOnly { get; set; }

        public double? BB { get; set; }

        public double? HB { get; set; }

        public double? FB { get; set; }

        public double? AllInclusive { get; set; }
    }
}
