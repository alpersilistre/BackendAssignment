using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class CreateLockRequest : IUseCaseRequest<CreateLockResponse>
    {
        [Required]
        public string Name { get; }
        [Required]
        public int CompanyId { get; }

        public CreateLockRequest(string name, int companyId)
        {
            Name = name;
            CompanyId = companyId;
        }
    }
}
