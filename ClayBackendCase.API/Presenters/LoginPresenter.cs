using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.Net;

namespace ClayBackendCase.API.Presenters
{
    public class LoginPresenter : BasePresenter, IOutputPort<LoginResponse>
    {
        public void Handle(LoginResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);

            Result.Content = response.Success ? SerializeObject(response.Token) : SerializeObject(response.Message);
        }
    }
}
