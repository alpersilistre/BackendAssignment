using ClayBackendCase.API.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.Interfaces
{
    public interface ILockRepository : IAsyncRepository<Lock>
    {
        Task<Lock> GetByIdWithCompanyAsync(int id);
        Task<List<Lock>> GetAllWithCompanyAsync();
    }
}
