using Domain.Interfaces;
using Domain.Model;

namespace BusinessLogic.Tests

{
    public class GoodServiceTest
    {
        private readonly GoodService service;
        private readonly Mock<IGoodsRepository> goodRepositoryMoq;

        public GoodServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            goodRepositoryMoq = new Mock<IGoodsRepository>();

            repositoryWrapperMoq.Setup(x => x.Good).Returns(goodRepositoryMoq.Object);
            
            service = new GoodService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullGood_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Good>()), Times.Never);
        }
        public static IEnumerable<object[]> GetIncorrectGood()
        {
            return new List<object[]>
            {
                new object[] { new Good() { Id=0,Category="",Title="",Price=-20,Amount=-1,Descryption="" } },
                new object[] { new Good() { Id=0,Category="Видеокарты",Title="",Price=-20,Amount=-1,Descryption="" } },
                new object[] { new Good() { Id=0,Category="Видеокарты",Title="1050ti",Price=-20,Amount=-1,Descryption="" } },
                new object[] { new Good() { Id=0,Category="Видеокарты",Title="1050ti",Price=20000,Amount=-1,Descryption="" } },
                new object[] { new Good() { Id=0,Category="Видеокарты",Title="1050ti",Price=20000,Amount=1,Descryption="" } }
            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectGood))]
        public async Task CreateAsync_NewGood_ShouldNotCreateNewGood(Good good)
        {
            var newGood = good;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newGood));

            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Good>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsync_NewGood_ShouldCreateNewGood()
        {
            var newGood = new Good() { Id = 0, Category = "Видеокарты", Title = "1050ti", Price = 20000, Amount = 1, Descryption = "ZV" } ;
            await service.Create(newGood);
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Good>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_NullGood_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            goodRepositoryMoq.Verify(x => x.Update(It.IsAny<Good>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectGood))]
        public async Task UpdateAsync_NewGood_ShouldNotUpdateGood(Good good)
        {
            var newGood = good;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(newGood));

            goodRepositoryMoq.Verify(x => x.Update(It.IsAny<Good>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task UpdateAsync_NewGood_ShouldUpdateGood()
        {
            var newGood = new Good() { Id = 0, Category = "Видеокарты", Title = "1050ti", Price = 20000, Amount = 1, Descryption = "Zeliboba" };
            await service.Update(newGood);

            goodRepositoryMoq.Verify(x => x.Update(It.IsAny<Good>()), Times.Once);
        }
    }
}