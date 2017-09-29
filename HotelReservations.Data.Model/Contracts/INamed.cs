using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Model.Contracts
{
    public interface INamed
    {
        string Name { get; set; }
    }
}
