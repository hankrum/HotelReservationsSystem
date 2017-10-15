using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Services.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IEfRepository<Reservation> reservationRepo;
        private readonly ISaveContext context;
        //private ICitiesService citiesService;
        //private ICountriesService countriesService;

        public ReservationService(
            IEfRepository<Reservation> reservationRepo,
            //ICountriesService countriesService,
            //ICitiesService citiesService,
            IEfRepository<Reservation> countriesRepo,
            ISaveContext context
            )
        {
            this.reservationRepo = reservationRepo;
            //this.citiesService = citiesService;
            //this.countriesService = countriesService;
            this.context = context;
        }

        public IQueryable<Reservation> GetAll()
        {
            return this.reservationRepo.All;
        }

        //public void Update(Reservation reservation)
        //{
        //    this.reservationRepo.Update(reservation);
        //    this.context.Commit();
        //}

        public void Add(Reservation reservation)
        {
            //City city = this.citiesService.GetByName(hotel.City.Name);
            //bool cityExists = city != null;

            //Country country = this.countriesService.GetByName(hotel.Country.Name);
            //bool countryExists = country != null;

            //if (cityExists)
            //{
            //    hotel.City = city;
            //}

            //if (countryExists)
            //{
            //    hotel.Country = country;
            //}

            //this.hotelsRepo.Add(hotel);
            //this.context.Commit();
        }

        //public Reservation GetById(Guid? Id)
        //{
        //    return this.reservationRepo.All.FirstOrDefault<Reservation>(x => x.Id == Id);
        //}
    }
}
