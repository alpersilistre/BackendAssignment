using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.UseCases
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(GetUsersRequest message, IOutputPort<GetUsersResponse> outputPort)
        {
            var users = new List<User>();

            if (message.Id.HasValue)
            {
                var user = await _userRepository.GetUser(message.Id.Value);

                users.Add(user);
            }
            else
            {
                users = (await _userRepository.GetUsers()).ToList();
            }            

            outputPort.Handle(new GetUsersResponse(users, true));

            return true;
        }
    }
}
