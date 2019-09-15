using ClayBackendCase.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayBackendCase.API.Core.Dto.UseCaseResponses
{
    public class LockingResponse : UseCaseResponseMessage
    {
        public bool IsLocked { get; set; }        

        public LockingResponse(bool success = false, string message = null) : base(success, message)
        {            
        }

        public LockingResponse(bool isLocked, bool success = true, string message = null) : base(success, message)
        {
            IsLocked = isLocked;
        }
    }
}
