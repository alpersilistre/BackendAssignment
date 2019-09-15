using ClayBackendCase.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClayBackendCase.API.Controllers
{
    [ModelValidation]
    public class BaseController : ControllerBase
    {     
        protected int GetUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "id");

            return int.Parse(userIdClaim.Value);
        }
    }
}
