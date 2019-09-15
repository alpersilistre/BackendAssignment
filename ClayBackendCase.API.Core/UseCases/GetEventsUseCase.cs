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
    public class GetEventsUseCase : IGetEventsUseCase
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(GetEventsRequest message, IOutputPort<GetEventsResponse> outputPort)
        {
            var events = new List<Event>();

            if (message.Id.HasValue)
            {
                var eventEntity = await _eventRepository.GetByIdAsync(message.Id.Value);

                events.Add(eventEntity);
            }
            else
            {
                events = (await _eventRepository.ListAllAsync()).ToList();
            }

            outputPort.Handle(new GetEventsResponse(events, true));

            return true;
        }
    }
}
