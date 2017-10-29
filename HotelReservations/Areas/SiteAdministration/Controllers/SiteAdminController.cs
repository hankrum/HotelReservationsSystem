using HotelReservations.Infrastructure;
using HotelReservations.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservations.Web.Areas.SiteAdministration.Controllers
{
    [Authorize(Roles = WebConstants.SiteAdminRoleString)]
    public class SiteAdminController : Controller
    {
        IUserService userService;

        public SiteAdminController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: SiteAdministration/SiteAdmin
        public ActionResult Index()
        {
            var hotelAdmins = this.userService.Get
            return View();
        }
    }
}