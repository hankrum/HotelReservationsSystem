﻿using HotelReservations.Data.Model;
using System.Linq;

namespace HotelReservations.Services.Contracts
{
    public interface IHotelsService
    {
        IQueryable<Hotel> GetAll();

        void Update(Hotel hotel);

        void Add(Hotel hotel);
   }
}