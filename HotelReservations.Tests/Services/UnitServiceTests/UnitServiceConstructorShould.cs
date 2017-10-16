using HotelReservations.Data.Model;
using HotelReservations.Data.Repositories;
using HotelReservations.Data.SaveContext;
using HotelReservations.Services.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Tests.Services.UnitServiceTests
{
    [TestFixture]
    public class UnitServiceConstructorShould
    {
        [Test]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            // Arrange
            var userRepoMock = new Mock<IEfRepository<User>>();
            var dbContextMock = new Mock<ISaveContext>();

            // Act
            UserService citiesService = new UserService(userRepoMock.Object, dbContextMock.Object);

            // Assert
            Assert.IsNotNull(citiesService);
        }

        [Test]
        public void ThrowException_WhenUserRepoIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(null, dbContextMock.Object));
        }

        [Test]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<User>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(repoMock.Object, null));
        }
    }
}
