using Bytes2you.Validation;
using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> usersRepo;
        private readonly ISaveContext context;
        private readonly IRoleService roleService;

        public UserService(
            IEfRepository<User> usersRepo, 
            ISaveContext context,
            IRoleService roleService
            )
        {
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(roleService, "roleService").IsNull().Throw();

            this.roleService = roleService;
            this.usersRepo = usersRepo;
            this.context = context;
        }

        public ICollection<IdentityUserRole> GetAllByRole(string roleName)
        {
            var role = this.roleService.GetByRoleName(roleName);
            var result = role.Users;    //this.usersRepo.All.Where(x => x.Roles.FirstOrDefault(r => r.RoleId == role.Id).RoleId == role.Id);

            return result;
        }

        public User GetByUserName(string userName)
        {
            return this.usersRepo.All.FirstOrDefault<User>(x => x.UserName == userName);
        }

        public User GetById(string id)
        {
            return this.usersRepo.All.FirstOrDefault<User>(x => x.Id == id);
        }
    }
}
