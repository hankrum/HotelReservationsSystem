﻿using HotelReservations.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservations.Web.Areas.HotelAdministration.Models
{
    public class HotelViewModel
    {
        public HotelViewModel()
        {

        }

        public HotelViewModel(Hotel hotel)
        {
            this.Name = hotel.Name;
            this.Stars = hotel.Stars;
            this.Address = hotel.Address;
            this.CityName = hotel.City.Name;
            this.CountryName = hotel.Country.Name;
            this.Zip = hotel.Zip;
            this.Rooms = new HashSet<RoomViewModel>();
            hotel.Rooms.Select(x => this.Rooms.Add(new RoomViewModel(x)));
            this.PhotoUrls = new HashSet<string>();
            hotel.PhotoUrls.Select(x => this.PhotoUrls.Add(x.Url));
            this.HasParking = hotel.HasParking;
            this.HasInternet = hotel.HasInternet;
            this.HasRestaurant = hotel.HasRestaurant;
        }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public short Stars { get; set; }

        public string Address { get; set; }

        [Required]
        [MinLength(2)]
        public string CityName { get; set; }

        [MinLength(2)]
        [MaxLength(10)]
        public string Zip { get; set; }

        [Required]
        [MinLength(2)]
        public string CountryName { get; set; }

        public HashSet<RoomViewModel> Rooms { get; set; }

        public HashSet<string> PhotoUrls { get; set; }

        public bool HasParking { get; set; }

        public bool HasRestaurant { get; set; }

        public bool HasInternet { get; set; }


        public Hotel CreateHotel()
        {
            var result = new Hotel();
            result.Name = this.Name;
            result.Stars = this.Stars;
            result.Address = this.Address;
            result.City = new City();
            result.City.Name = this.CityName;
            result.Country = new Country();
            result.Country.Name = this.CountryName;
            result.Zip = this.Zip;
            result.Rooms = new HashSet<Room>();
            // TODO: to fix rooms
            result.PhotoUrls = new HashSet<PhotoUrl>();

            if (this.PhotoUrls != null)
            {
                foreach (var photo in this.PhotoUrls)
                {
                    var photoUrl = new PhotoUrl();
                    photoUrl.Url = photo;
                    result.PhotoUrls.Add(photoUrl);
                }
            }

            result.HasInternet = this.HasInternet;
            result.HasParking = this.HasParking;
            result.HasRestaurant = this.HasRestaurant;

            return result;
        }
    }
}