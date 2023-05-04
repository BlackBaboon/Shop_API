using Domain.Interfaces;
using Domain.Model;

namespace BusinessLogic.Tests

{
    public class LikedListServiceTest
    {
        private readonly LikedListService service;
        private readonly Mock<ILikedListRepository> likedListRepositoryMoq;

        public LikedListServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            likedListRepositoryMoq = new Mock<ILikedListRepository>();

            repositoryWrapperMoq.Setup(x => x.LikedList).Returns(likedListRepositoryMoq.Object);
            
            service = new LikedListService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullLikedList_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            likedListRepositoryMoq.Verify(x => x.Create(It.IsAny<LikedList>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_NewLikedList_ShouldCreateNewLikedList()
        {
            var newLikedList = new LikedList() { GoodId = 0, UserId = 0 };
            await service.Create(newLikedList);

            likedListRepositoryMoq.Verify(x => x.Create(It.IsAny<LikedList>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_NullLikedList_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            likedListRepositoryMoq.Verify(x => x.Update(It.IsAny<LikedList>()), Times.Never);
        }

        [Fact]
        public async Task UpdateAsync_NewLikedList_ShouldUpdateLikedList()
        {
            var newLikedList = new LikedList() { GoodId = 0,UserId=0 };
            await service.Update(newLikedList);

            likedListRepositoryMoq.Verify(x => x.Update(It.IsAny<LikedList>()), Times.Once);
        }
    }
}