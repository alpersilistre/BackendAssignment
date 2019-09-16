using ClayBackendCase.API.Core.Entities;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.Interfaces
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<Company> GetFirstCompanyAsync();
    }
}
