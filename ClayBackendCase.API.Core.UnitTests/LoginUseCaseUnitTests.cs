using ClayBackendCase.API.Core.Dto;
using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.Auth;
using ClayBackendCase.API.Core.UseCases;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ClayBackendCase.API.Core.UnitTests
{
    public class LoginUseCaseUnitTests
    {
        [Fact]
        public async void Can_Login()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository
                .Setup(repo => repo.GetByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User("", "")));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(new Token("", "", 0, "")));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // Arrange
            var response = await useCase.Handle(new LoginRequest("username", "password"), mockOutputPort.Object);

            // Arrange
            Assert.True(response);
        }

        [Fact]
        public async void Cant_Login_When_Username_Is_Missing()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.GetByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User("", "")));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(new Token("", "", 0, "")));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }

        [Fact]
        public async void Cant_Login_When_Password_Is_Missing()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.GetByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User("", "")));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(new Token("", "", 0, "")));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("username", ""), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }

        [Fact]
        public async void Cant_Login_When_Password_Is_Not_Valid()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.GetByName(It.IsAny<string>()))
                .Returns(Task.FromResult<User>(null));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(false));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(await Task.FromResult(new Token("", "", 0, "")));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("username", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
    }
}
