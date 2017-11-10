using HotelReservations.Infrastructure;
using HotelReservations.Services.Contracts;
using HotelReservations.Web.Areas.SiteAdministration.Models;
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
            HotelAdminsViewModel hotelAdmins = new HotelAdminsViewModel();

            var users = this.userService.GetAllByRole(WebConstants.HotelAdminRoleString);
            var collectionUsers = new List<HotelAdminViewModel>();

            foreach (var user in users)
            {

                HotelAdminViewModel hotelAdmin = new HotelAdminViewModel(this.userService);
                hotelAdmin.UserName = hotelAdmin.GetModel(user).UserName;
                collectionUsers.Add(hotelAdmin);
            }

            hotelAdmins.HotelAdmins = collectionUsers;

            //hotelAdmins.HotelAdmins = users.//.Select(hotelAdmin.GetModel);

            return View(hotelAdmins);
        }
    }
}