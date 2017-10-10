using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservations.Web.Areas.SiteAdministration.Controllers
{
    public class SiteAdminController : Controller
    {
        // GET: SiteAdministration/SiteAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}