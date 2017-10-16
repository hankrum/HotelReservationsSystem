using Bytes2you.Validation;
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
        private IUserService userService;

        public HotelsService(
            IEfRepository<Hotel> hotelsRepo,
            ICountriesService countriesService,
            ICitiesService citiesService,
            IUserService userService,
            IEfRepository<Country> countriesRepo,
            ISaveContext context
            )
        {
            Guard.WhenArgument(hotelsRepo, "hotelsRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(countriesService, "countriesService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(citiesService, "citiesService").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(countriesRepo, "countriesRepo").IsNull().Throw();

            this.hotelsRepo = hotelsRepo;
            this.citiesService = citiesService;
            this.countriesService = countriesService;
            this.userService = userService;
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
            User user = this.userService.GetById(hotel.User.Id);
            bool userExists = user != null;

            if (userExists)
            {
                hotel.User = user;
            }
            else
            {
                throw new ArgumentNullException("User cannot be null");
            }

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

        public Hotel GetByName(string name)
        {
            return this.hotelsRepo.All.FirstOrDefault<Hotel>(h => h.Name == name);
        }

    }
}
