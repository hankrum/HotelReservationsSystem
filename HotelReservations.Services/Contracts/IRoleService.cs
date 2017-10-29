using HotelReservations.Data.Model;

namespace HotelReservations.Services.Contracts
{
    public interface IRoleService
    {
        Role GetByRoleName(string roleName);

        Role GetById(string id);
    }
}
