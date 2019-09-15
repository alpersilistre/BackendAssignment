using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.Net;

namespace ClayBackendCase.API.Presenters.Locks
{
    public class LockingPresenter : BasePresenter, IOutputPort<LockingResponse>
    {
        public void Handle(LockingResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            Result.Content = response.Success ?
                SerializeObject(response.IsLocked ? new { locked_state = "Locked" } : new { locked_state = "Unlocked" }) :
                SerializeObject(response.Message);
        }
    }
}
