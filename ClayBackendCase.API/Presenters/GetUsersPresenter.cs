using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.Linq;
using System.Net;

namespace ClayBackendCase.API.Presenters
{
    public class GetUsersPresenter : BasePresenter, IOutputPort<GetUsersResponse>
    {        
        public void Handle(GetUsersResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            Result.Content = response.Success ?
                SerializeObject(response.Users.Select(x => new { x.Id, x.FirstName, x.LastName })) :
                SerializeObject(response.Errors);
        }
    }
}
