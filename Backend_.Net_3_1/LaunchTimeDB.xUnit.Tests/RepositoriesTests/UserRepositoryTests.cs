using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace LaunchTimeDB.xUnit.Tests.RepositoriesTests
{
   public class UserRepositoryTests
    {
        private readonly IUserRepository _mockRepository;
        private readonly Mock<IUserRepository> mock;

        public UserRepositoryTests()
        {
            mock = new Mock<IUserRepository>();

            IList<User> profileTypes = new List<User>()
            {
                new User("somename1","pas@word", "First Name"),
                new User("somename2", "pmsF2R4Z", "Last Name"),
                new User("somename3", "myPassword", "Some Name")
            };
            // Mock GetAll.
            mock.Setup(x => x.GetAll()).Returns(profileTypes);

            // Mock Insert.
            mock.Setup(x => x.Insert(It.IsAny<User>()))
                .Returns(new User(1, "saved", "pas@word", "Saved"));

            _mockRepository = mock.Object;
        }

        [Fact(DisplayName = "Insert User Repository - Success")]
        public void Insert_User_Repository_Success()
        {
            var profileType = new User("tosave", "tXmmm!@#", "To Save");

            var result = _mockRepository.Insert(profileType);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "GetAll Users Repository - Success")]
        public void GetAll_Users_GetAll()
        {
            var allUsers = _mockRepository.GetAll();

            Assert.NotNull(allUsers);
            Assert.NotEqual(0, allUsers.Count);
        }
    }
}
