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

        public UserService(IEfRepository<User> usersRepo, ISaveContext context)
        {
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.usersRepo = usersRepo;
            this.context = context;
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
