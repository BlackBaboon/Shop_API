using Domain.Interfaces;
using Domain.Model;

namespace BusinessLogic.Tests

{
    public class ShipsServiceTest
    {
        private readonly ShipService service;
        private readonly Mock<IShipsRepository> shipRepositoryMoq;

        public ShipsServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            shipRepositoryMoq = new Mock<IShipsRepository>();

            repositoryWrapperMoq.Setup(x => x.Ship).Returns(shipRepositoryMoq.Object);
            
            service = new ShipService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullShip_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            shipRepositoryMoq.Verify(x => x.Create(It.IsAny<Ship>()), Times.Never);
        }
        public static IEnumerable<object[]> GetIncorrectShip()
        {
            return new List<object[]>
            {
                new object[] { new Ship() { Id = 1, UserId = 1, GoodId = 1, Amount = 0, ShipDate = new DateTime(2023, 12, 22), Status = "" } },
                new object[] { new Ship() { Id = 1, UserId = 1, GoodId = 1, Amount = 12, ShipDate = new DateTime(2022, 12, 22), Status = "" } },
                new object[] { new Ship() { Id = 1, UserId = 1, GoodId = 1, Amount = 12, ShipDate = new DateTime(2022, 12, 12), Status = "" } }
            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectShip))]
        public async Task CreateAsync_newShip_ShouldNotCreatenewShip(Ship ship)
        {
            var newShip = ship;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newShip));

            shipRepositoryMoq.Verify(x => x.Create(It.IsAny<Ship>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsync_newShip_ShouldCreateNewShip()
        {
            var newShip = new Ship() { Id = 1, UserId = 1, GoodId = 1, Amount = 12,ShipDate = new DateTime(2022,12,12),Status="норм"  };
            await service.Create(newShip);
            shipRepositoryMoq.Verify(x => x.Create(It.IsAny<Ship>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_NullShip_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));
            
            Assert.IsType<ArgumentNullException>(ex);
            shipRepositoryMoq.Verify(x => x.Update(It.IsAny<Ship>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectShip))]
        public async Task UpdateAsync_newShip_ShouldNotUpdateShip(Ship ship)
        {
            var newShip = ship;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(newShip));

            shipRepositoryMoq.Verify(x => x.Update(It.IsAny<Ship>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task UpdateAsync_newShip_ShouldUpdateShip()
        {
            var newShip = new Ship() { Id = 1, UserId = 1, GoodId = 1, Amount = 12, ShipDate = new DateTime(2022, 12, 12), Status = "норм" };
            await service.Update(newShip);

            shipRepositoryMoq.Verify(x => x.Update(It.IsAny<Ship>()), Times.Once);
        }
    }
}