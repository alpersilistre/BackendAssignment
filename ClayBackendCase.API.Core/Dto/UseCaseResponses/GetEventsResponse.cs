using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using System.Collections.Generic;

namespace ClayBackendCase.API.Core.Dto.UseCaseResponses
{
    public class GetEventsResponse : UseCaseResponseMessage
    {
        public IEnumerable<Event> Events { get; }

        public GetEventsResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public GetEventsResponse(IEnumerable<Event> events, bool success = false, string message = null) : base(success, message)
        {
            Events = events;
        }
    }
}
