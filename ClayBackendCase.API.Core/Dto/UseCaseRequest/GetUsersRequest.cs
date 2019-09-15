using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class GetUsersRequest : IUseCaseRequest<GetUsersResponse>
    {
        public int? Id { get; set; }

        public GetUsersRequest(int? id = null)
        {
            Id = id;
        }
    }
}
