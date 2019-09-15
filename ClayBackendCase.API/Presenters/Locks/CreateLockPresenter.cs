using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.Net;

namespace ClayBackendCase.API.Presenters.Locks
{
    public class CreateLockPresenter : BasePresenter, IOutputPort<CreateLockResponse>
    {
        public void Handle(CreateLockResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            Result.Content = response.Success ? SerializeObject(response) : SerializeObject(response.Message);
        }
    }
}
