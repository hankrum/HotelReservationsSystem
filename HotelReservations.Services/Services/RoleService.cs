using Bytes2you.Validation;
using HotelReservations.Data;
using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Services.Services
{
    public class RoleService : IRoleService
    {
        //private readonly IEfRepository<Role> rolesRepo;
        private readonly MsSqlDbContext dbContext;
        //private readonly ISaveContext context;
        private RoleManager<IdentityRole> RoleManager; 

        public RoleService(MsSqlDbContext dbContext)
        {
            //Guard.WhenArgument(rolesRepo, "rolesRepo").IsNull().Throw();
            //Guard.WhenArgument(context, "context").IsNull().Throw();

            //this.rolesRepo = rolesRepo;
            this.dbContext = dbContext;
            this.RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.dbContext));
            //this.context = context;
        }

        //public static IdentityRole GetIdentityRole(string roleName)
        //{
        //    return this.RoleManager.FindByName(roleName);
        //}

        public IdentityRole GetByRoleName(string roleName)
        {
            return this.RoleManager.FindByName(roleName);
        }

        public IdentityRole GetById(string id)
        {
            return this.RoleManager.FindById(id);
        }
    }
}
