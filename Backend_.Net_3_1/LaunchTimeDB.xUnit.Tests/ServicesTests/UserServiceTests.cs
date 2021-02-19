using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using LaunchTimeDB.Domain.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LaunchTimeDB.xUnit.Tests.ServicesTests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly IUserService _service;

        public UserServiceTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _service = new UserService(_mockRepository.Object);
        }

        [Theory(DisplayName = "Insert User Service - Success")]
        [InlineData(1,"user1", "pass@SFF", "Usuario 1")]
        [InlineData(5,"user132", "my!pass%_x", "Usuário 123")]
        [InlineData(35, "otherUser", "otherPassword", "Outro Usuário")]
        public void Insert_User_Service_Success(long id, string userName, string password, string name)
        {
            // Arrange
            Mock<User> mockExpectedProfileType = new Mock<User>();
            mockExpectedProfileType.SetupGet(f => f.Id).Returns(id);
            mockExpectedProfileType.SetupGet(f => f.UserName).Returns(userName);
            mockExpectedProfileType.SetupGet(f => f.Password).Returns(password);
            mockExpectedProfileType.SetupGet(f => f.Name).Returns(name);

            _mockRepository.Setup(f => f.GetAll()).Returns(new List<User>());
            _mockRepository.Setup(f => f.Insert(It.IsAny<User>())).Returns(mockExpectedProfileType.Object);

            // Action
            var result = _service.Insert(new User(userName, password, name));

            // Assert
            _mockRepository.Verify(f => f.Insert(It.Is<User>(f => f.UserName == userName && f.Password == password)), Times.Once);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "GetAll User Service")]
        public void GetAll_User_Service()
        {
            // Arrange
            IList<User> userSystem = GetMockSetupList();
            _mockRepository.Setup(x => x.GetAll()).Returns(userSystem);

            // Action
            var getAllUserSystems = _service.GetAll();

            // Assert
            _mockRepository.Verify(f => f.GetAll(), Times.Once);
            Assert.Equal(3, getAllUserSystems.Count);
        }

        [Fact(DisplayName = "GetById UserService")]
        public void GetById_User_Service()
        {
            // Arrange
            long id = 123;

            Mock<User> mockUserSystem = new Mock<User>();
            mockUserSystem.SetupGet(f => f.Id).Returns(id);
            mockUserSystem.SetupGet(f => f.UserName).Returns($"some userName 4");
            mockUserSystem.SetupGet(f => f.Password).Returns($"some password 4");
            mockUserSystem.SetupGet(f => f.Name).Returns("Meu Nome");
            mockUserSystem.SetupGet(f => f.CreatedDate).Returns(DateTime.Now);
            mockUserSystem.SetupGet(f => f.UpdatedDate).Returns(DateTime.Now);

            _mockRepository.Setup(x => x.GetById(It.IsAny<long>())).Returns(mockUserSystem.Object);

            // Action
            var profileType = _service.GetById(id);

            // Assert
            _mockRepository.Verify(f => f.GetById(It.IsAny<long>()), Times.Once);
            Assert.NotNull(profileType);
        }

        [Fact(DisplayName = "Delete ById UserSystem Service")]
        public void DeleteById_UserSystem_Service()
        {
            // Arrange
            int id = 5;
            _mockRepository.Setup(f => f.DeleteById(id));

            // Action
            _service.DeleteById(id);

            // Assert
            _mockRepository.Verify(f => f.DeleteById(id), Times.Once);
        }

        #region .: PRIVATE METHODS :.
        private IList<User> GetMockSetupList()
        {
            Mock<List<Mock<User>>> mockSetupList = new Mock<List<Mock<User>>>();

            for (int i = 1; i <= 3; i++)
            {
                Mock<User> mockUserSystems = new Mock<User>();
                mockUserSystems.SetupGet(f => f.Id).Returns(i);
                mockUserSystems.SetupGet(f => f.UserName).Returns($"some userName {i}");
                mockUserSystems.SetupGet(f => f.Password).Returns($"pa$sword {i}");
                mockUserSystems.SetupGet(f => f.Name).Returns($"Nome do Usuário {i}");
                mockUserSystems.SetupGet(f => f.CreatedDate).Returns(DateTime.Now);
                mockUserSystems.SetupGet(f => f.UpdatedDate).Returns(DateTime.Now);
                mockSetupList.Object.Add(mockUserSystems);
            }
            IList<User> userSystems = new List<User>();

            foreach (var item in mockSetupList.Object)
                userSystems.Add(item.Object);

            return userSystems;
        }
        #endregion
    }
}
