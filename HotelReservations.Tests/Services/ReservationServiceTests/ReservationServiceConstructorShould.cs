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
    public class ReservationServiceConstructorShould
    {
        [Test]
        public void ReturnsAnInstance_WhenAllParametersAreNotNull()
        {
            // Arrange
            var reservationRepoMock = new Mock<IEfRepository<Reservation>>();
            var hotelsServiceMock = new Mock<IHotelsService>();
            var userServiceMock = new Mock<IUserService>();
            var dbContextMock = new Mock<ISaveContext>();

            // Act
            ReservationService reservationService = new ReservationService(
                reservationRepoMock.Object,
                hotelsServiceMock.Object,
                userServiceMock.Object,
                dbContextMock.Object
                );

            // Assert
            Assert.IsNotNull(reservationService);
        }

        [Test]
        public void ThrowException_WhenReservationRepoIsNull()
        {
            // Arrange
            var reservationRepoMock = new Mock<IEfRepository<Reservation>>();
            var hotelsServiceMock = new Mock<IHotelsService>();
            var userServiceMock = new Mock<IUserService>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ReservationService
                (
                    null,
                    hotelsServiceMock.Object,
                    userServiceMock.Object,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenHotelsServiceIsNull()
        {
            // Arrange
            var reservationRepoMock = new Mock<IEfRepository<Reservation>>();
            var hotelsServiceMock = new Mock<IHotelsService>();
            var userServiceMock = new Mock<IUserService>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ReservationService
                (
                    reservationRepoMock.Object,
                    null,
                    userServiceMock.Object,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenUserServiceIsNull()
        {
            // Arrange
            var reservationRepoMock = new Mock<IEfRepository<Reservation>>();
            var hotelsServiceMock = new Mock<IHotelsService>();
            var userServiceMock = new Mock<IUserService>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ReservationService
                (
                    reservationRepoMock.Object,
                    hotelsServiceMock.Object,
                    null,
                    dbContextMock.Object
                ));
        }

        [Test]
        public void ThrowException_WhenContextIsNull()
        {
            // Arrange
            var reservationRepoMock = new Mock<IEfRepository<Reservation>>();
            var hotelsServiceMock = new Mock<IHotelsService>();
            var userServiceMock = new Mock<IUserService>();
            var dbContextMock = new Mock<ISaveContext>();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ReservationService
                (
                    reservationRepoMock.Object,
                    hotelsServiceMock.Object,
                    userServiceMock.Object,
                    null
                ));
        }

    }
}
