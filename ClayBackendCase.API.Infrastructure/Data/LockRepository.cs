using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Infrastructure.Data
{
    public class LockRepository : EfRepository<Lock>, ILockRepository
    {
        public LockRepository(DataContext dbContext) : base(dbContext)
        {            
        }

        public async Task<Lock> GetByIdWithCompanyAsync(int id)
        {
            return await _dbContext.Locks
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Lock>> GetAllWithCompanyAsync()
        {
            return await _dbContext.Locks
                .Include(x => x.Company)
                .ToListAsync();
        }

        public async Task<List<Lock>> GetAllByCompanyIdAsync(int id)
        {
            return await _dbContext.Locks
                .Where(x => x.Company.Id == id)
                .Include(x => x.Company)
                .ToListAsync();
        }
    }
}
