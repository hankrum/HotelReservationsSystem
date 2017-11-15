using HotelReservations.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Services.Contracts
{
    public interface IReservationService
    {
        IQueryable<Reservation> GetAll();

        IQueryable<Reservation> GetByUser(string userName);

        void Add(Reservation reservation);
    }
}
