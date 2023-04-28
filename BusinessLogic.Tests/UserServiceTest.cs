using Domain.Interfaces;
using Domain.Model;

namespace BusinessLogic.Tests

{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User).Returns(userRepositoryMoq.Object);
            
            service = new UserService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }
        public static IEnumerable<object[]> GetIncorrectUser()
        {
            return new List<object[]>
            { 
                new object[] { new User() { Id = 100, Nickname = "", Surname = "", Name = "", Email = "", Password = "", Phonenumber = "", 
                    Authed = true, IsAdmin = false, IsDelete = false, } },
                new object[] { new User() { Id = 101, Nickname = "test", Surname = "", Name = "", Email = "", Password = "", Phonenumber = "", 
                    Authed = true, IsAdmin = false, IsDelete = false, } },
                new object[] { new User() { Id = 102, Nickname = "test", Surname = "test", Name = "", Email = "", Password = "", Phonenumber = "", 
                    Authed = true, IsAdmin = false, IsDelete = false, } },
                new object[] { new User() { Id = 103, Nickname = "test", Surname = "test", Name = "test", Email = "", Password = "", Phonenumber = "", 
                    Authed = true, IsAdmin = false, IsDelete = false, } },
                new object[] { new User() { Id = 104, Nickname = "test", Surname = "test", Name = "test", Email = "test", Password = "test", Phonenumber = "", 
                    Authed = false, IsAdmin = false, IsDelete = false, } }
            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUser))]
        public async Task CreateAsync_NewUser_ShouldNotCreateNewUser(User user)
        {
            var newUser = user;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsync_NewUser_ShouldCreateNewUser()
        {
            var newUser = new User() { Id = 15, Nickname = "zxc sf 1v1 mid", Surname = "fedorok", Name = "artem", Email = "213@mail.com", Password = "1488228322", Phonenumber = "82283371488", Authed = true, IsAdmin = false, IsDelete = false, };
            await service.Create(newUser);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUser))]
        public async Task UpdateAsync_NewUser_ShouldNotUpdateUser(User user)
        {
            var newUser = user;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(newUser));

            userRepositoryMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task UpdateAsync_NewUser_ShouldUpdateUser()
        {
            var newUser = new User() { Id = 1, Nickname = "zxc sf 1v1 mid", Surname = "fedorok", Name = "artem", Email = "213@mail.com", Password = "1488228322", Phonenumber = "82283371488", Authed = true, IsAdmin = false, IsDelete = false, };
            await service.Update(newUser);

            userRepositoryMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }
    }
}