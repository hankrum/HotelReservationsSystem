using HotelReservations.Data.Model;
using HotelReservations.Data.Model.Contracts;
using HotelReservations.Data.Model.PriceModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<City> Cities { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Hotel> Hotels { get; set; }
        public IDbSet<PriceGroup> PriceGroups { get; set; }
        public IDbSet<PricePeriod> PricePeriods { get; set; }
        public IDbSet<PriceSet> PriceSets { get; set; }
        public IDbSet<Reservation> Reservations { get; set; }
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<RoomType> RoomTypes { get; set; }
        public IDbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }
    }
}
