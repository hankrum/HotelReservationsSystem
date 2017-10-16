using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Services;
using Moq;
using NUnit.Framework;
using System;

namespace HotelReservations.Tests.Services.CitiesServiceTests
{
    [TestFixture]
    public class CitiesServiceConstructorShould
    {
        [Test]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            // Arrange
            var cityRepoMock = new Mock<IEfRepository<City>>();
            var dbContextMock = new Mock<ISaveContext>();

            // Act
            CitiesService citiesService = new CitiesService(cityRepoMock.Object, dbContextMock.Object);

            // Assert
            Assert.IsNotNull(citiesService);
        }

        [Test]
        public void ThrowException_WhenCityRepoIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CitiesService(null, dbContextMock.Object));
        }

        [Test]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<City>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CitiesService(repoMock.Object, null));
        }
    }
}
