using Bytes2you.Validation;
using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using System.Linq;

namespace HotelReservations.Services.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IEfRepository<City> citiesRepo;
        private readonly ISaveContext context;

        public CitiesService(IEfRepository<City> citiesRepo, ISaveContext context)
        {
            Guard.WhenArgument(citiesRepo, "citiesRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.citiesRepo = citiesRepo;
            this.context = context;
        }

        //public IEfRepository<City> Repo
        //{
        //    get
        //    {
        //        return this.citiesRepo;
        //    }
        //}

        //IQueryable<City> GetAll()
        //{
        //    return this.citiesRepo.All;
        //}

        //City GetById(Guid Id)
        //{
        //    return this.citiesRepo.All.FirstOrDefault<City>(x => x.Id == Id);
        //}

        //public void Attach(City city)
        //{
        //    this.citiesRepo.
        //}

        public City GetByName(string name)
        {
            return this.citiesRepo.All.FirstOrDefault<City>(x => x.Name == name);
        }
    }
}
