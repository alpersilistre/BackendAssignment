using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.Linq;
using System.Net;

namespace ClayBackendCase.API.Presenters.Locks
{
    public class GetLockPresenter : BasePresenter, IOutputPort<GetLocksResponse>
    {
        public void Handle(GetLocksResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            Result.Content = response.Success ?
                SerializeObject(response.Locks.Select(x => new
                {
                    x.Id,
                    x.Name,
                    locked_state = x.IsLocked ? "Locked" : "Unlocked",
                    company_id = x.Company.Id,
                    company_name = x.Company.Name
                }).FirstOrDefault()) :
                SerializeObject(response.Errors);
        }
    }
}
