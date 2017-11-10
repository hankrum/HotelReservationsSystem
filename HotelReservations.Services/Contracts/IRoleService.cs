using HotelReservations.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelReservations.Services.Contracts
{
    public interface IRoleService
    {
        IdentityRole GetByRoleName(string roleName);

        IdentityRole GetById(string id);
    }
}
