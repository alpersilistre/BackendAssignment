using ClayBackendCase.API.Core.Dto.Repository;
using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClayBackendCase.API.Core.UnitTests
{
    public class RegisterUseCaseUnitTests
    {
        //[Fact]
        //public async void Can_Register()
        //{
        //    // Arrange
        //    var mockUserRepository = new Mock<IUserRepository>();
        //    var mockRoleRepository = new Mock<IRoleRepository>();

        //    mockUserRepository
        //        .Setup(repo => repo.GetByName(It.IsAny<string>()))
        //        .Returns(Task.FromResult<User>(null));

        //    mockUserRepository
        //        .Setup(repo => repo.CheckAdminUserExist())
        //        .Returns(Task.FromResult(true));

        //    mockRoleRepository
        //        .Setup(repo => repo.GetByName(It.IsAny<string>()))
        //        .Returns(Task.FromResult(new Role("")));

        //    mockUserRepository
        //        .Setup(repo => repo.Create(new User(), It.IsAny<string>()))
        //        .Returns(Task.FromResult(new CreateUserResponse("", true)));

        //    var useCase = new RegisterUseCase(mockUserRepository.Object, mockRoleRepository.Object);

        //    var mockOutputPort = new Mock<IOutputPort<RegisterUserResponse>>();
        //    mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RegisterUserResponse>()));

        //    // Arrange
        //    var response = await useCase.Handle(new RegisterUserRequest("firstname", "lastname", "username", "password"), mockOutputPort.Object);

        //    // Arrange
        //    Assert.True(response);
        //}
    }
}
