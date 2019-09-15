using ClayBackendCase.API.Core.Interfaces;
using System.Collections.Generic;

namespace ClayBackendCase.API.Core.Dto.UseCaseResponses
{
    public class LoginResponse : UseCaseResponseMessage
    {
        public Token Token { get; }

        public LoginResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public LoginResponse(Token token, bool success = false, string message = null) : base(success, message)
        {
            Token = token;
        }
    }
}
