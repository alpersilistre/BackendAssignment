using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.Net;

namespace ClayBackendCase.API.Presenters
{
    public class RegisterUserPresenter : BasePresenter, IOutputPort<RegisterUserResponse>
    {
        public void Handle(RegisterUserResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            Result.Content = response.Success ? SerializeObject(response) : SerializeObject(response.Errors);
        }
    }
}
