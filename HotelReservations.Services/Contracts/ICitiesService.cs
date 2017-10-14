using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Services.Contracts
{
    public interface ICitiesService
    {
        //IEfRepository<City> Repo { get; }

        City GetByName(string name);
    }
}
