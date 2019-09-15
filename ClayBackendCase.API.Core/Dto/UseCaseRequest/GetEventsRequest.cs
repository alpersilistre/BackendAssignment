using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class GetEventsRequest : IUseCaseRequest<GetEventsResponse>
    {
        public int? Id { get; set; }

        public GetEventsRequest(int? id = null)
        {
            Id = id;
        }
    }
}
