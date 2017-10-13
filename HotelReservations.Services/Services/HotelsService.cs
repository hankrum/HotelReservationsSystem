using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using System.Linq;

namespace HotelReservations.Services.Services
{
    public class HotelsService : IHotelsService
    {
        private readonly IEfRepository<Hotel> hotelsRepo;
        private readonly ISaveContext context;

        public HotelsService(IEfRepository<Hotel> hotelsRepo, ISaveContext context)
        {
            this.hotelsRepo = hotelsRepo;
            this.context = context;
        }

        public IQueryable<Hotel> GetAll()
        {
            return this.hotelsRepo.All;
        }

        public void Update(Hotel hotel)
        {
            this.hotelsRepo.Update(hotel);
            this.context.Commit();
        }

        public void Add(Hotel hotel)
        {
            this.hotelsRepo.Add(hotel);
            this.context.Commit();
        }
    }
}
