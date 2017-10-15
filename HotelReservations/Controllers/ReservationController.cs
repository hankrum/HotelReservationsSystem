using HotelReservations.Services.Contracts;
using HotelReservations.Services.Services;
using HotelReservations.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservations.Web.Controllers
{

    [Authorize]
    public class ReservationController : Controller
    {
        private IReservationService reservationService;
        private IHotelsService hotelService;
        private IUserService userService;

        public ReservationController(
            IReservationService reservationService,
            IUserService userService,
            IHotelsService hotelService
            )
        {
            this.reservationService = reservationService;
            this.hotelService = hotelService;
            this.userService = userService;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public ActionResult Add(Guid? id)
        {
            var hotel = this.hotelService.GetById(id);
            ViewBag.HotelId = id;
            ViewBag.HotelName = hotel.Name;
            

            return View();
        }

        [HttpPost]
        public ActionResult Add(ReservationViewModel model)
        {
            var user = User.Identity;
            var dbUser = this.userService.GetByUserName(user.Name);
            model.UserId = dbUser.Id;

            var reservation = model.CreateReservation();

            this.reservationService.Add(reservation);

            return RedirectToAction("Index", "Hotels");
        }
    }
}