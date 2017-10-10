﻿using HotelReservations.Data.Model.Contracts;
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
    public class HotelAdminViewModel : IdentityUser, IAuditable, IDeletable
    {
        //private ICollection<Reservation> reservations;

        //public UserViewModel()
        //{
        //    //this.reservations = new HashSet<Reservation>();
        //}

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

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