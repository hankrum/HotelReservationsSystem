using HotelReservations.Data.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.Abstractions
{
    public class NamedModel : DataModel, INamed
    {
        [Index]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
