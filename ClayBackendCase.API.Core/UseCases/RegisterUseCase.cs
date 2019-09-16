using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.Auth;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.UseCases
{
    public class RegisterUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICompanyRepository _companyRepository;

        public RegisterUseCase(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            ICompanyRepository companyRepository
            )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var existingUser = await _userRepository.GetByName(message.UserName);

            if (existingUser != null)
            {
                outputPort.Handle(new RegisterUserResponse(false, "Username already exist."));

                return false;
            }

            Role role;

            if (!await _userRepository.CheckAdminUserExist())
            {
                role = await _roleRepository.GetByName("Admin");
            }
            else
            {
                role = await _roleRepository.GetByName("User");
            }

            // For simplicity, first company will be set to User on creation
            var company = await _companyRepository.GetFirstCompanyAsync();

            var response = await _userRepository.Create(new User
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                UserName = message.UserName,
                Role = role,
                Company = role.Name == "Admin" ? null : company,
                Created = DateTime.UtcNow
            }, message.Password);

            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Id, false, response.Error));

            return response.Success;
        }
    }
}
