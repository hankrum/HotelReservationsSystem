using Bytes2you.Validation;
using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
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
        private readonly IEfRepository<Role> rolesRepo;
        private readonly ISaveContext context;

        public RoleService(IEfRepository<Role> rolesRepo, ISaveContext context)
        {
            Guard.WhenArgument(rolesRepo, "rolesRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.rolesRepo = rolesRepo;
            this.context = context;
        }

        public Role GetByRoleName(string roleName)
        {
            return this.rolesRepo.All.FirstOrDefault<Role>(x => x.Name == roleName);
        }

        public Role GetById(string id)
        {
            return this.rolesRepo.All.FirstOrDefault<Role>(x => x.Id == id);
        }
    }
}
