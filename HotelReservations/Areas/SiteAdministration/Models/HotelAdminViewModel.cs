using HotelReservations.Data.Model;
using HotelReservations.Data.Model.Contracts;
using HotelReservations.Services.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HotelReservations.Web.Areas.SiteAdministration.Models
{
    public class HotelAdminViewModel //: IdentityUser, IAuditable, IDeletable
    {
        private readonly IUserService userService;

        public HotelAdminViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public string UserName { get; set; }

        public HotelAdminViewModel GetModel(IdentityUserRole user)
        {
            var result = new HotelAdminViewModel(this.userService);
            result.UserName = this.userService.GetById(user.UserId).UserName;

            return result;
        }

        //[Index]
        //public bool IsDeleted { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime? DeletedOn { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime? CreatedOn { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime? ModifiedOn { get; set; }

        //public virtual ICollection<Reservation> Reservations
        //{
        //    get
        //    {
        //        return this.reservations;
        //    }
        //    set
        //    {
        //        this.reservations = value;
        //    }
        //}

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<HotelAdminViewModel> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
    }
}