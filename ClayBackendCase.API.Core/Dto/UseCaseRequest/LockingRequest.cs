using ClayBackendCase.API.Core.Dto.UseCaseResponses;
using ClayBackendCase.API.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ClayBackendCase.API.Core.Dto.UseCaseRequest
{
    public class LockingRequest : IUseCaseRequest<LockingResponse>
    {
        [Required]
        public bool IsLocked { get; }

        public int Id { get; set; }

        public int UserId { get; set; }

        public LockingRequest(int id, bool isLocked, int userId)
        {
            Id = id;
            IsLocked = isLocked;
            UserId = userId;
        }
    }
}
