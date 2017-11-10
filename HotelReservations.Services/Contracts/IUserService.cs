using HotelReservations.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservations.Services.Contracts
{
    public interface IUserService
    {
        User GetByUserName(string userName);

        User GetById(string id);

        ICollection<IdentityUserRole> GetAllByRole(string roleName);
    }
}
