using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayBackendCase.API.Core.Dto.UseCaseResponses
{
    public class GetUsersResponse : UseCaseResponseMessage
    {
        public IEnumerable<User> Users { get; }

        public IEnumerable<Error> Errors { get; }

        public GetUsersResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetUsersResponse(IEnumerable<User> users, bool success = false, string message = null) : base(success, message)
        {
            Users = users;
        }
    }
}
