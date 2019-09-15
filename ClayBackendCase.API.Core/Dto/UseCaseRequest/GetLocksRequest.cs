using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class GetLocksRequest : IUseCaseRequest<GetLocksResponse>
    {
        public int? Id { get; set; }

        public GetLocksRequest(int? id = null)
        {
            Id = id;
        }
    }
}
