using Domain.Interfaces;
using Domain.Model;

namespace BusinessLogic.Tests

{
    public class CommentsServiceTest
    {
        private readonly CommentService service;
        private readonly Mock<ICommentRepository> commentRepositoryMoq;

        public CommentsServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            commentRepositoryMoq = new Mock<ICommentRepository>();

            repositoryWrapperMoq.Setup(x => x.Comment).Returns(commentRepositoryMoq.Object);
            
            service = new CommentService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullComment_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            commentRepositoryMoq.Verify(x => x.Create(It.IsAny<Comment>()), Times.Never);
        }
        public static IEnumerable<object[]> GetIncorrectComment()
        {
            return new List<object[]>
            { 
                new object[] { new Comment{ UserId=1,GoodId=1,Comment_="",Rate=0 } },
                new object[] { new Comment{ UserId=1,GoodId=1,Comment_="עוךסע",Rate=-1 } }
            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectComment))]
        public async Task CreateAsync_NewComment_ShouldNotCreateNewComment(Comment comment)
        {
            var newComment = comment;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newComment));

            commentRepositoryMoq.Verify(x => x.Create(It.IsAny<Comment>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsync_NewComment_ShouldCreateNewComment()
        {
            var newComment = new Comment { UserId = 1, GoodId = 1, Comment_ = "û", Rate = 3 };
            await service.Create(newComment);
            commentRepositoryMoq.Verify(x => x.Create(It.IsAny<Comment>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_NullComment_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            commentRepositoryMoq.Verify(x => x.Update(It.IsAny<Comment>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectComment))]
        public async Task UpdateAsync_NewComment_ShouldNotUpdateComment(Comment comment)
        {
            var newComment = comment;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(newComment));

            commentRepositoryMoq.Verify(x => x.Update(It.IsAny<Comment>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task UpdateAsync_NewComment_ShouldUpdateComment()
        {
            var newComment = new Comment { UserId = 1, GoodId = 1, Comment_ = "אûûûû", Rate = 3 };
            await service.Update(newComment);

            commentRepositoryMoq.Verify(x => x.Update(It.IsAny<Comment>()), Times.Once);
        }
    }
}