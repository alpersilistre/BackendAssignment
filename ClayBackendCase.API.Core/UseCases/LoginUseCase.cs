using ClayBackendCase.API.Core.Dto;
using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.Auth;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.UserName) && !string.IsNullOrEmpty(message.Password))
            {
                var user = await _userRepository.GetByName(message.UserName);

                if (user != null)
                {
                    if (_userRepository.CheckPassword(user, message.Password))
                    {
                        outputPort.Handle(new LoginResponse(_jwtFactory.GenerateToken(user.Id.ToString(), user.UserName, user.Role?.Name), true));

                        return true;
                    }
                }
            }

            outputPort.Handle(new LoginResponse(false, "Invalid username or password."));

            return false;
        }
    }
}
