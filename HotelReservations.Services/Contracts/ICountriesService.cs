using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;

namespace HotelReservations.Services.Contracts
{
    public interface ICountriesService
    {
        //IEfRepository<Country> Repo { get; }

        Country GetByName(string name);
    }
}
