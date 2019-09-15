using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {
        [Required]
        public string FirstName { get; }
        [Required]
        public string LastName { get; }
        [Required]
        public string UserName { get; }
        [Required]
        public string Password { get; }

        public RegisterUserRequest(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }
    }
}
