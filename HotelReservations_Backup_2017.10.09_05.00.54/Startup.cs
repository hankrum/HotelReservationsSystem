using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelReservations.Startup))]
namespace HotelReservations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
