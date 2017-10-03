using HotelReservations.Data.Model.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservations.Data.Model.Abstractions
{
    public class NamedModel : DataModel, INamed
    {
        [Index(IsUnique = true)]
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
