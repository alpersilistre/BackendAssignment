using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using System;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.UseCases
{
    public class CreateLockUseCase : ICreateLockUseCase
    {
        private readonly ILockRepository _lockRepository;
        private readonly ICompanyRepository _companyRepository;

        public CreateLockUseCase(
            ILockRepository lockRepository,
            ICompanyRepository companyRepository
            )
        {
            _lockRepository = lockRepository;
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(CreateLockRequest message, IOutputPort<CreateLockResponse> outputPort)
        {
            var company = await _companyRepository.GetByIdAsync(message.CompanyId);

            if (company != null)
            {
                var entityLock = new Lock
                {
                    Name = message.Name,
                    IsLocked = true,
                    Company = company,
                    Created = DateTime.UtcNow,
                };

                var dbLock = await _lockRepository.AddAsync(entityLock);

                outputPort.Handle(new CreateLockResponse(dbLock, true));

                return true;
            }

            outputPort.Handle(new CreateLockResponse(true, "Company does not exist."));

            return false;
        }
    }
}
