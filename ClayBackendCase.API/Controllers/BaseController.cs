using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Controllers
{
    public class BaseController : ControllerBase
    {     
        protected int GetUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "id");

            return int.Parse(userIdClaim.Value);
        }
    }
}
