using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Infrastructure.Data
{
    public class CompanyRepository : EfRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DataContext dbContext) : base(dbContext)
        {            
        }

        public async Task<Company> GetFirstCompanyAsync()
        {
            return await _dbContext.Companies.FirstAsync();
        }
    }
}
