using HotelReservations.Infrastructure;
using HotelReservations.Services.Contracts;
using HotelReservations.Web.Areas.HotelAdministration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservations.Web.Areas.HotelAdministration.Controllers
{
    [Authorize(Roles = WebConstants.HotelAdminRoleString)]
    public class HotelController : Controller
    {
        private readonly IHotelsService hotelsService;

        public HotelController(IHotelsService hotelsService)
        {
            this.hotelsService = hotelsService;
        }

        // GET: HotelAdministration/Hotel
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(HotelViewModel hotel)
        {
            this.hotelsService.Add(hotel.CreateHotel());
            return RedirectToAction("Index");
        }

    }
}