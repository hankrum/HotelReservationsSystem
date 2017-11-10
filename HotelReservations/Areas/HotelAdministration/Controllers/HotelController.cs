using Bytes2you.Validation;
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
        private readonly IUserService userService;

        public HotelController(IHotelsService hotelsService, IUserService userService)
        {
            Guard.WhenArgument(hotelsService, "hotelsService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            this.hotelsService = hotelsService;
            this.userService = userService;
        }

        // GET: HotelAdministration/Hotel
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(HotelViewModel hotel)
        {
            var user = User.Identity;
            var dbUser = this.userService.GetByUserName(user.Name);
            hotel.UserId = dbUser.Id;

            this.hotelsService.Add(hotel.CreateHotel());
            return RedirectToAction("Index");
        }

    }
}