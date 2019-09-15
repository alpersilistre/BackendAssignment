using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using System.Collections.Generic;

namespace ClayBackendCase.API.Core.Dto.UseCaseResponses
{
    public class CreateLockResponse : UseCaseResponseMessage
    {
        public Lock Lock { get; set; }

        public CreateLockResponse(bool success = false, string message = null) : base(success, message)
        {
            
        }

        public CreateLockResponse(Lock _lock, bool success = false, string message = null) : base(success, message)
        {
            Lock = _lock;
        }
    }
}
