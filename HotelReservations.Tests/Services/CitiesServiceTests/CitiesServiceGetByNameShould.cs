using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace HotelReservations.Tests.Services.CitiesServiceTests
{
    [TestFixture]
    public class CitiesServiceGetByNameShould
    {
        [Test]
        public void ReturnModel_WhenThereIsAModelWithThePassedName()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<City>>();
            var dbContextMock = new Mock<ISaveContext>();



            repoMock.Setup(m => m.Add(new City() { Name = "PeshoCity" })); //.Returns(new City() { Name = "PeshoCity" });

            CitiesService citiesService = new CitiesService(repoMock.Object, dbContextMock.Object);

            // Act
            City city = citiesService.GetByName("PeshoCity");

            // Assert
            Assert.IsNotNull(city);
        }

        [Test]
        public void ReturnNull_WhenNameIsNull()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<City>>();
            var dbContextMock = new Mock<ISaveContext>();

            CitiesService citiesService = new CitiesService(repoMock.Object, dbContextMock.Object);

            // Act
            City city = citiesService.GetByName(null);

            // Assert
            Assert.IsNull(city);
        }

        [Test]
        public void ReturnNull_WhenThereIsNoModelWithThePassedName()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<City>>();
            var dbContextMock = new Mock<ISaveContext>();

            repoMock.Setup(m => m.Add(new City() { Name = "PeshoCity" })).Returns((City)null);

            CitiesService citiesService = new CitiesService(repoMock.Object, dbContextMock.Object);

            // Act
            City city = citiesService.GetByName("Pesho");

            // Assert
            Assert.IsNull(city);
        }
    }
}
