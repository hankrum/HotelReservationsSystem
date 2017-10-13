using HotelReservations.Services.Contracts;
using HotelReservations.Web.Models;
using HotelReservations.Web.Areas.HotelAdministration.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservations.Web.Controllers
{
    public class HotelsController : Controller
    {
        private IHotelsService hotelsService;

        protected HotelsController(IHotelsService hotelsService)
        {
            this.hotelsService = hotelsService;
        }

        // GET: Hotels
        [HttpGet]
        public ActionResult Index()
        {
            var hotels = new HotelsViewModel();

            hotels.Collection = this.hotelsService
                .GetAll()
                .Select(x => new HotelViewModel(x))
                .ToList();

            return View(hotels);
        }
    }
}