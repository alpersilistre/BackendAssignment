using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;

namespace ClayBackendCase.API.Infrastructure.Data
{
    public class CompanyRepository : EfRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
