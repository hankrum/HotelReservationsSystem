using HotelReservations.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Services.Contracts
{
    public interface IUserService
    {
        User GetByUserName(string userName);

        User GetById(string id);
    }
}
