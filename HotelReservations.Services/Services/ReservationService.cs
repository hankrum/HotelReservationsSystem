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
        private IUserService userService;
        private IHotelsService hotelsService;

        public ReservationService(
            IEfRepository<Reservation> reservationRepo,
            IHotelsService hotelsService,
            IUserService userService,
            IEfRepository<Reservation> countriesRepo,
            ISaveContext context
            )
        {
            this.reservationRepo = reservationRepo;
            this.userService = userService;
            this.hotelsService = hotelsService;
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
            User user = this.userService.GetById(reservation.User.Id);
            bool userExists = user != null;

            Hotel hotel = this.hotelsService.GetById(reservation.Hotel.Id);
            bool hotelExists = hotel != null;

            if (userExists)
            {
                reservation.User = user;
            }

            if (hotelExists)
            {
                reservation.Hotel = hotel;
            }

            this.reservationRepo.Add(reservation);
            this.context.Commit();
        }

        //public Reservation GetById(Guid? Id)
        //{
        //    return this.reservationRepo.All.FirstOrDefault<Reservation>(x => x.Id == Id);
        //}
    }
}
