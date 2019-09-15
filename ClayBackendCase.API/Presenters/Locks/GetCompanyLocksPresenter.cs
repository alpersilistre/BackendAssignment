using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Presenters.Locks
{
    public class GetCompanyLocksPresenter : BasePresenter, IOutputPort<GetCompanyLocksResponse>
    {
        public void Handle(GetCompanyLocksResponse response)
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
                })) :
                SerializeObject(response.Message);
        }
    }
}
