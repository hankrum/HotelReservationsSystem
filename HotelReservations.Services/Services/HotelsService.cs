using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using System;
using System.Linq;

namespace HotelReservations.Services.Services
{
    public class HotelsService : IHotelsService
    {
        private readonly IEfRepository<Hotel> hotelsRepo;
        private readonly ISaveContext context;
        private ICitiesService citiesService;
        private ICountriesService countriesService;

        public HotelsService(
            IEfRepository<Hotel> hotelsRepo,
            ICountriesService countriesService,
            ICitiesService citiesService,
            IEfRepository<Country> countriesRepo,
            ISaveContext context
            )
        {
            this.hotelsRepo = hotelsRepo;
            this.citiesService = citiesService;
            this.countriesService = countriesService;
            this.context = context;
        }

        public IQueryable<Hotel> GetAll()
        {
            return this.hotelsRepo.All;
        }

        public void Update(Hotel hotel)
        {
            this.hotelsRepo.Update(hotel);
            this.context.Commit();
        }

        public void Add(Hotel hotel)
        {
            City city = this.citiesService.GetByName(hotel.City.Name);
            bool cityExists = city != null;

            Country country = this.countriesService.GetByName(hotel.Country.Name);
            bool countryExists = country != null;

            if (cityExists)
            {
                hotel.City = city;
            }

            if (countryExists)
            {
                hotel.Country = country;
            }

            this.hotelsRepo.Add(hotel);
            this.context.Commit();
        }

        public Hotel GetById(Guid? Id)
        {
            return this.hotelsRepo.All.FirstOrDefault<Hotel>(x => x.Id == Id);
        }

    }
}
