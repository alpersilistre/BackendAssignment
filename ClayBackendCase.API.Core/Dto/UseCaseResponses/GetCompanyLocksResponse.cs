using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayBackendCase.API.Core.Dto.UseCaseResponses
{
    public class GetCompanyLocksResponse : UseCaseResponseMessage
    {
        public IEnumerable<Lock> Locks { get; }

        public GetCompanyLocksResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public GetCompanyLocksResponse(IEnumerable<Lock> locks, bool success = false, string message = null) : base(success, message)
        {
            Locks = locks;
        }
    }
}
