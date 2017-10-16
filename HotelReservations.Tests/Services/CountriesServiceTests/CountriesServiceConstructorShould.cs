using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Services;
using Moq;
using NUnit.Framework;
using System;

namespace HotelReservations.Tests.Services.CountriesServiceTests
{
    [TestFixture]
    public class CountriesServiceConstructorShould
    {
        [Test]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            // Arrange
            var countryRepoMock = new Mock<IEfRepository<Country>>();
            var dbContextMock = new Mock<ISaveContext>();

            // Act
            CountriesService countriesService = new CountriesService(countryRepoMock.Object, dbContextMock.Object);

            // Assert
            Assert.IsNotNull(countriesService);
        }

        [Test]
        public void ThrowException_WhenCityRepoIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CountriesService(null, dbContextMock.Object));
        }

        [Test]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Country>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CountriesService(repoMock.Object, null));
        }
    }
}
