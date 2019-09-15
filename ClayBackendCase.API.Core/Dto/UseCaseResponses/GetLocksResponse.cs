using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using System.Collections.Generic;

namespace ClayBackendCase.API.Core.Dto.UseCaseResponses
{
    public class GetLocksResponse : UseCaseResponseMessage
    {
        public IEnumerable<Lock> Locks { get; }

        public IEnumerable<Error> Errors { get; }

        public GetLocksResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetLocksResponse(IEnumerable<Lock> locks, bool success = false, string message = null) : base(success, message)
        {
            Locks = locks;
        }
    }
}
