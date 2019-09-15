using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Infrastructure.Data
{
    public class RoleRepository : EfRepository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<Role> GetByName(string name)
        {
            return await _dbContext.Roles
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
