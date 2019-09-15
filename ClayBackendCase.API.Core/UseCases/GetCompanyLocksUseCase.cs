using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.UseCases
{
    class GetCompanyLocksUseCase : IGetCompanyLocksUseCase
    {
        private readonly ILockRepository _lockRepository;

        public GetCompanyLocksUseCase(ILockRepository lockRepository)
        {
            _lockRepository = lockRepository;
        }

        public async Task<bool> Handle(GetCompanyLocksRequest message, IOutputPort<GetCompanyLocksResponse> outputPort)
        {
            var locks = new List<Lock>();

            locks = await _lockRepository.GetAllByCompanyIdAsync(message.Id);

            outputPort.Handle(new GetCompanyLocksResponse(locks, true));

            return true;
        }
    }
}
