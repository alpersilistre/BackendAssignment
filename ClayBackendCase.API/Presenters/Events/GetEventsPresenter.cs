using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.Linq;
using System.Net;

namespace ClayBackendCase.API.Presenters.Events
{
    public class GetEventsPresenter : BasePresenter, IOutputPort<GetEventsResponse>
    {
        public void Handle(GetEventsResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            Result.Content = response.Success ?
                SerializeObject(response.Events.Select(x => new
                {
                    x.Id,
                    x.Detail
                })) :
                SerializeObject(response.Message);
        }
    }
}
