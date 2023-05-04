using Domain.Interfaces;
using Domain.Model;

namespace BusinessLogic.Tests

{
    public class GoodsListServiceTest
    {
        private readonly GoodsListService service;
        private readonly Mock<IGoodsListRepository> goodsListRepositoryMoq;

        public GoodsListServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            goodsListRepositoryMoq = new Mock<IGoodsListRepository>();

            repositoryWrapperMoq.Setup(x => x.GoodsList).Returns(goodsListRepositoryMoq.Object);
            
            service = new GoodsListService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullGoodsList_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            goodsListRepositoryMoq.Verify(x => x.Create(It.IsAny<GoodsList>()), Times.Never);
        }
        public static IEnumerable<object[]> GetIncorrectGoodsList()
        {
            return new List<object[]>
            {
                new object[] { new GoodsList() { GoodId=1,UserId=1,Amount=0 } }
            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectGoodsList))]
        public async Task CreateAsync_NewGoodsList_ShouldNotCreateNewGoodsList(GoodsList goodsList)
        {
            var newGoodsList = goodsList;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newGoodsList));

            goodsListRepositoryMoq.Verify(x => x.Create(It.IsAny<GoodsList>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsync_NewGoodsList_ShouldCreateNewGoodsList()
        {
            var newGoodsList = new GoodsList() { GoodId = 1, UserId = 1, Amount = 2 };
            await service.Create(newGoodsList);
            goodsListRepositoryMoq.Verify(x => x.Create(It.IsAny<GoodsList>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_NullGoodsList_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            goodsListRepositoryMoq.Verify(x => x.Update(It.IsAny<GoodsList>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectGoodsList))]
        public async Task UpdateAsync_NewGoodsList_ShouldNotUpdateGoodsList(GoodsList goodsList)
        {
            var newGoodsList = goodsList;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(newGoodsList));

            goodsListRepositoryMoq.Verify(x => x.Update(It.IsAny<GoodsList>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task UpdateAsync_NewGoodsList_ShouldUpdateGoodsList()
        {
            var newGoodsList = new GoodsList() { GoodId = 1, UserId = 1, Amount = 2 }; 
            await service.Update(newGoodsList);

            goodsListRepositoryMoq.Verify(x => x.Update(It.IsAny<GoodsList>()), Times.Once);
        }
    }
}