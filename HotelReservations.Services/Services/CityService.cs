using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using System;
using System.Linq;

namespace HotelReservations.Services.Services
{
    public class CityService
    {
        private readonly IEfRepository<City> citiesRepo;
        private readonly ISaveContext context;

        public CityService(IEfRepository<City> citiesRepo, ISaveContext context)
        {
            this.citiesRepo = citiesRepo;
            this.context = context;
        }

        IQueryable<City> GetAll()
        {
            return this.citiesRepo.All;
        }

        City GetById (Guid Id)
        {
            return this.citiesRepo.All.FirstOrDefault<City>(x => x.Id == Id);
        }
    }
}
