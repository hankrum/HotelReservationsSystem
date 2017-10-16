using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Contracts;
using HotelReservations.Services.Services;
using Moq;
using NUnit.Framework;
using System;

namespace HotelReservations.Tests.Services.CitiesServiceTests
{
    [TestFixture]
    public class HotelsServiceConstructorShould
    {
        [Test]
        public void ReturnsAnInstance_WhenAllParametersAreNotNull()
        {
            // Arrange
            var hotelRepoMock = new Mock<IEfRepository<Hotel>>();
            var countriesServiceMock = new Mock<ICountriesService>();
            var citiesServiceMock = new Mock<ICitiesService>();
            var userServiceMock = new Mock<IUserService>();
            var countriesRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();

            // Act
            HotelsService hotelsService = new HotelsService(
                hotelRepoMock.Object,
                countriesServiceMock.Object,
                citiesServiceMock.Object,
                userServiceMock.Object,
                countriesRepoMock.Object,
                dbContextMock.Object
                );

            // Assert
            Assert.IsNotNull(hotelsService);
        }

        [Test]
        public void ThrowException_WhenHotelRepoIsNull()
        {
            // Arrange
            var hotelRepoMock = new Mock<IEfRepository<Hotel>>();
            var countriesServiceMock = new Mock<ICountriesService>();
            var citiesServiceMock = new Mock<ICitiesService>();
            var userServiceMock = new Mock<IUserService>();
            var countriesRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HotelsService
                (
                    null,
                    countriesServiceMock.Object,
                    citiesServiceMock.Object,
                    userServiceMock.Object,
                    countriesRepoMock.Object,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenCountriesServiceIsNull()
        {
            // Arrange
            var hotelRepoMock = new Mock<IEfRepository<Hotel>>();
            var countriesServiceMock = new Mock<ICountriesService>();
            var citiesServiceMock = new Mock<ICitiesService>();
            var userServiceMock = new Mock<IUserService>();
            var countriesRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HotelsService
                (
                    hotelRepoMock.Object,
                    null,
                    citiesServiceMock.Object,
                    userServiceMock.Object,
                    countriesRepoMock.Object,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenCitiesServiceIsNull()
        {
            // Arrange
            var hotelRepoMock = new Mock<IEfRepository<Hotel>>();
            var countriesServiceMock = new Mock<ICountriesService>();
            var citiesServiceMock = new Mock<ICitiesService>();
            var userServiceMock = new Mock<IUserService>();
            var countriesRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HotelsService
                (
                    hotelRepoMock.Object,
                    countriesServiceMock.Object,
                    null,
                    userServiceMock.Object,
                    countriesRepoMock.Object,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenUserServiceIsNull()
        {
            // Arrange
            var hotelRepoMock = new Mock<IEfRepository<Hotel>>();
            var countriesServiceMock = new Mock<ICountriesService>();
            var citiesServiceMock = new Mock<ICitiesService>();
            var userServiceMock = new Mock<IUserService>();
            var countriesRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HotelsService
                (
                    hotelRepoMock.Object,
                    countriesServiceMock.Object,
                    citiesServiceMock.Object,
                    null,
                    countriesRepoMock.Object,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenCountriesRepoIsNull()
        {
            // Arrange
            var hotelRepoMock = new Mock<IEfRepository<Hotel>>();
            var countriesServiceMock = new Mock<ICountriesService>();
            var citiesServiceMock = new Mock<ICitiesService>();
            var userServiceMock = new Mock<IUserService>();
            var countriesRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HotelsService
                (
                    hotelRepoMock.Object,
                    countriesServiceMock.Object,
                    citiesServiceMock.Object,
                    userServiceMock.Object,
                    null,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenContextIsNull()
        {
            // Arrange
            var hotelRepoMock = new Mock<IEfRepository<Hotel>>();
            var countriesServiceMock = new Mock<ICountriesService>();
            var citiesServiceMock = new Mock<ICitiesService>();
            var userServiceMock = new Mock<IUserService>();
            var countriesRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HotelsService
                (
                    hotelRepoMock.Object,
                    countriesServiceMock.Object,
                    citiesServiceMock.Object,
                    userServiceMock.Object,
                    countriesRepoMock.Object,
                    null
                ));
        }

    }
}
