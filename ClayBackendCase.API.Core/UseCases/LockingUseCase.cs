using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using System;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.UseCases
{
    public class LockingUseCase : ILockingUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILockRepository _lockRepository;
        private readonly IEventRepository _eventRepository;

        public LockingUseCase(
            IUserRepository userRepository,
            ILockRepository lockRepository,
            IEventRepository eventRepository
        )
        {
            _userRepository = userRepository;
            _lockRepository = lockRepository;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(LockingRequest message, IOutputPort<LockingResponse> outputPort)
        {
            var entityLock = await _lockRepository.GetByIdWithCompanyAsync(message.Id);

            if (entityLock != null)
            {
                var user = await _userRepository.GetByIdWithRelationsAsync(message.UserId);

                if (user.Role.Name != "Admin" && user.Company.Id != entityLock.Company.Id)
                {
                    outputPort.Handle(new LockingResponse(false, "User not authorized to update the lock."));

                    return false;
                }

                entityLock.IsLocked = message.IsLocked;

                await _lockRepository.UpdateAsync(entityLock);
                
                var eventDetail = message.IsLocked ?
                    $"{user.FirstName} {user.LastName} locked {entityLock.Name}({entityLock.Company.Name})" :
                    $"{user.FirstName} {user.LastName} unlocked {entityLock.Name}({entityLock.Company.Name})";

                await _eventRepository.AddAsync(new Event
                {
                    Detail = eventDetail,
                    Created = DateTime.UtcNow,
                    Lock = entityLock,
                    User = user
                });

                outputPort.Handle(new LockingResponse(message.IsLocked, true));

                return true;
            }

            outputPort.Handle(new LockingResponse(false, "Lock can't be updated"));

            return false;
        }
    }
}
