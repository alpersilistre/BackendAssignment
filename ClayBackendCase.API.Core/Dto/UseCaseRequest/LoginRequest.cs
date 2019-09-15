using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        [Required]
        public string UserName { get; }

        [Required]
        public string Password { get; }

        public LoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
