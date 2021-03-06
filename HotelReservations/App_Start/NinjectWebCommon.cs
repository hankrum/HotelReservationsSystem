[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HotelReservations.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HotelReservations.Web.App_Start.NinjectWebCommon), "Stop")]

namespace HotelReservations.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using HotelReservations.Data.Repositories;
    using HotelReservations.Data;
    using Ninject.Extensions.Conventions;
    using System.Data.Entity;
    using HotelReservations.Data.SaveContext;
    using AutoMapper;
    using HotelReservations.Services.Contracts;
    using HotelReservations.Services.Services;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            //kernel.Bind(x =>
            //{
            //    x.FromAssemblyContaining(typeof(IService))
            //     .SelectAllClasses()
            //     .BindDefaultInterface();
            //});

            kernel.Bind(typeof(DbContext), typeof(MsSqlDbContext)).To<MsSqlDbContext>().InRequestScope();
            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EFRepository<>));
            kernel.Bind<ISaveContext>().To<SaveContext>();
            //kernel.Bind<IMapper>().To<Mapper>();

            kernel.Bind<IHotelsService>().To<HotelsService>();
            kernel.Bind<ICitiesService>().To<CitiesService>();
            kernel.Bind<ICountriesService>().To<CountriesService>();
            kernel.Bind<IReservationService>().To<ReservationService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();


        }
    }
}
