using HotelReservations.Services.Contracts;
using HotelReservations.Web.Models;
using HotelReservations.Web.Areas.HotelAdministration.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using HotelReservations.Data.Model;

namespace HotelReservations.Web.Controllers
{
    public class HotelsController : Controller
    {
        private IHotelsService hotelsService;

        public HotelsController(IHotelsService hotelsService)
        {
            this.hotelsService = hotelsService;
        }

        // GET: Hotels
        [HttpGet]
        public ActionResult Index()
        {
            var hotels = new HotelsViewModel();
            hotels.Collection = new List<HotelViewModel>();

            var dbHotels = this.hotelsService
                .GetAll()
                //.Select(x => new HotelViewModel(x))
                .ToList();

            foreach (var dbHotel in dbHotels)
            {
                var hotel = new HotelViewModel(dbHotel);
                hotels.Collection.Add(hotel);
            }

            return View(hotels.Collection);
        }

        public ActionResult Details(Guid? id)
        {
            Hotel hotel = this.hotelsService.GetById(id);

            HotelViewModel viewModel = new HotelViewModel(hotel);

            return this.View(viewModel);
        }

    }
}