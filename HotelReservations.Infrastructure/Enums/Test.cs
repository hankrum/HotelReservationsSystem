using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Infrastructure.Enums
{
    class Test
    {
        public void Pr()
        {
            var x = Enum.GetValues(typeof(MealPlan))
    .Cast<MealPlan>()
    .Select(v => v.ToString())
    .ToList();
        }
    }
}
