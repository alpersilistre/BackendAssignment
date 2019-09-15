using ClayBackendCase.API.Core.Entities;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.Interfaces
{
    public interface IRoleRepository : IAsyncRepository<Role>
    {
        Task<Role> GetByName(string name);
    }
}
