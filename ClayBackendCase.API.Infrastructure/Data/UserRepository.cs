using ClayBackendCase.API.Core.Dto.Repository;
using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Infrastructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByIdWithRoleAsync(int id)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByIdWithCompanyAsync(int id)
        {
            return await _dbContext.Users
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByIdWithRelationsAsync(int id)
        {
            return await _dbContext.Users
                .Include(x => x.Company)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByName(string userName)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users
                .Select(x => new User
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users
                .Include(x => x.Company)
                .Select(x => new User
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Company = x.Company
                })
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CheckAdminUserExist()
        {
            return await _dbContext.Users.AnyAsync(x => x.Role.Name == "Admin");
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            try
            {
                await AddAsync(user);

                return new CreateUserResponse(user.Id.ToString(), true);
            }
            catch
            {
                return new CreateUserResponse(user.Id.ToString(), false, "Cannot create a user");
            }                        
        }

        public bool CheckPassword(User user, string password)
        {
            return VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {            
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException();
            }

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
