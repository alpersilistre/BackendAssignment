using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class GetCompanyLocksRequest : IUseCaseRequest<GetCompanyLocksResponse>
    {
        public int Id { get; set; }

        public GetCompanyLocksRequest(int id)
        {
            Id = id;
        }
    }
}
