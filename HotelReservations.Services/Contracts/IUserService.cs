using HotelReservations.Data.Model;
using System.Linq;

namespace HotelReservations.Services.Contracts
{
    public interface IUserService
    {
        User GetByUserName(string userName);

        User GetById(string id);

        IQueryable<User> GetAllByRole(string roleName);
    }
}
