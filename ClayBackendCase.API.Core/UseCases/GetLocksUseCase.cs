using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.UseCases
{
    public class GetLocksUseCase : IGetLocksUseCase
    {
        private readonly ILockRepository _lockRepository;

        public GetLocksUseCase(ILockRepository lockRepository)
        {
            _lockRepository = lockRepository;
        }

        public async Task<bool> Handle(GetLocksRequest message, IOutputPort<GetLocksResponse> outputPort)
        {
            var locks = new List<Lock>();

            if (message.Id.HasValue)
            {
                var lockEntity = await _lockRepository.GetByIdWithCompanyAsync(message.Id.Value);

                locks.Add(lockEntity);
            }
            else
            {
                locks = await _lockRepository.GetAllWithCompanyAsync();
            }

            outputPort.Handle(new GetLocksResponse(locks, true));

            return true;
        }
    }
}
