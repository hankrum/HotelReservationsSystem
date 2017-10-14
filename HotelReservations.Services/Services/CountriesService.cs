using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Services.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IEfRepository<Country> countriesRepo;
        private readonly ISaveContext context;

        public CountriesService(IEfRepository<Country> countriesRepo, ISaveContext context)
        {
            this.countriesRepo = countriesRepo;
            this.context = context;
        }

        //public IEfRepository<Country> Repo
        //{
        //    get
        //    {
        //        return this.countriesRepo;
        //    }
        //}

        public Country GetByName(string name)
        {
            return this.countriesRepo.All.FirstOrDefault<Country>(x => x.Name == name);
        }
    }
}
