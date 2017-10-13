using HotelReservations.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Web.Areas.HotelAdministration.Models
{
    public class RoomViewModel
    {
        public RoomViewModel()
        {

        }

        public RoomViewModel(Room room)
        {

        }

        Room CreateRoom()
        {
            return new Room();
        }
    }
}